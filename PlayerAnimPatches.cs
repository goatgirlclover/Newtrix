using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Reptile;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace trickyclown
{
    public class ABPatchesTC
    {
        public static Dictionary<int, Dictionary<int, float>> customBlendingFromTo = new();
        public static Dictionary<int, float> alwaysBlendOut = new(); 
        public static Dictionary<int, float> alwaysBlendIn = new();

        public static void ParseCustomBlending()
        {
            customBlendingFromTo.Clear();
            alwaysBlendIn.Clear();
            alwaysBlendOut.Clear();

            string customsUnsplit = BPatchTC.customAnimationBlending.Value;
            if (string.IsNullOrWhiteSpace(customsUnsplit)) return;

            string[] customs = customsUnsplit.Replace(", ", ",").Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string custom in customs)
            {
                string trimmedCustom = custom.Trim();
                if (string.IsNullOrWhiteSpace(trimmedCustom)) continue;
                try
                {
                    int colonIndex = trimmedCustom.LastIndexOf(':');
                    if (colonIndex == -1) 
                        throw new FormatException("Missing blend time separator (:)");

                    string selector = trimmedCustom.Substring(0, colonIndex);
                    string blendValueString = trimmedCustom.Substring(colonIndex + 1);

                    if (!float.TryParse(blendValueString, out float blend))
                        throw new FormatException($"Blend time '{blendValueString}' invalid - check formatting");

                    string[] splitByArrows = selector.Split('>');
                    switch (splitByArrows.Length)
                    {
                        case 1: // "animation:outBlend" (equivalent to "animation>*:blend")
                            HandleSingleAnimationRule(splitByArrows[0], blend);
                            break;
                        case 2: // "animation1>animation2:blend"
                            HandleTwoAnimationRule(splitByArrows[0], splitByArrows[1], blend);
                            break;
                        case 3: // "animation1>animation2>animation3:inOutBlend"
                            HandleThreeAnimationRule(splitByArrows[0], splitByArrows[1], splitByArrows[2], blend);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Improper formatting - number of arrows (>) outside of range (0-2)");
                    }
                } catch (Exception ex) {
                    Debug.LogWarning($"(NewTrix/ABPatchesTC) Failed parsing custom animation blending string '{trimmedCustom}': {ex.Message}");
                }
            }
        }

        private static void HandleSingleAnimationRule(string fromPart, float blend)
        {
            int animationFrom = AnimationUtility.GetAnimationByName(fromPart.Trim());
            alwaysBlendOut[animationFrom] = blend;
        }

        private static void HandleTwoAnimationRule(string fromPart, string toPart, float blend)
        {
            string trimmedFrom = fromPart.Trim();
            string trimmedTo = toPart.Trim();

            bool alwaysOut = trimmedTo == "*";
            bool alwaysIn = trimmedFrom == "*";

            if (alwaysOut && alwaysIn)
            {
                throw new Exception("Improper rule - use defaultAnimationBlend in config instead!");
            }
            else if (alwaysOut)
            {
                int animationFrom = AnimationUtility.GetAnimationByName(trimmedFrom);
                alwaysBlendOut[animationFrom] = blend;
            }
            else if (alwaysIn)
            {
                int animationTo = AnimationUtility.GetAnimationByName(trimmedTo);
                alwaysBlendIn[animationTo] = blend;
            }
            else
            {
                int animationFrom = AnimationUtility.GetAnimationByName(trimmedFrom);
                int animationTo = AnimationUtility.GetAnimationByName(trimmedTo);
                AddCustomBlending(animationFrom, animationTo, blend);
            }
        }

        private static void HandleThreeAnimationRule(string fromPart, string middlePart, string toPart, float blend)
        {
            string trimmedStart = fromPart.Trim();
            string trimmedMiddle = middlePart.Trim();
            string trimmedEnd = toPart.Trim();

            bool alwaysOut = trimmedStart == "*";
            bool alwaysIn = trimmedEnd == "*";

            if (trimmedMiddle == "*")
                throw new Exception("Improper rule - use defaultAnimationBlend in config instead!");

            if (alwaysOut && alwaysIn)
            {
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                alwaysBlendIn[animationMiddle] = blend;
                alwaysBlendOut[animationMiddle] = blend;
            }
            else if (alwaysOut)
            {
                int animationFrom = AnimationUtility.GetAnimationByName(trimmedStart);
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                alwaysBlendOut[animationMiddle] = blend;
                AddCustomBlending(animationFrom, animationMiddle, blend);
            }
            else if (alwaysIn)
            {
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                int animationTo = AnimationUtility.GetAnimationByName(trimmedEnd);
                alwaysBlendIn[animationMiddle] = blend;
                AddCustomBlending(animationMiddle, animationTo, blend);
            }
            else
            {
                int animationFrom = AnimationUtility.GetAnimationByName(trimmedStart);
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                int animationTo = AnimationUtility.GetAnimationByName(trimmedEnd);
                AddCustomBlending(animationFrom, animationMiddle, blend);
                AddCustomBlending(animationMiddle, animationTo, blend);
            }
        }

        private static void AddCustomBlending(int animationFrom, int animationTo, float blend) {
            if (!customBlendingFromTo.ContainsKey(animationFrom)) { customBlendingFromTo[animationFrom] = new(); }
            Dictionary<int, float> value = customBlendingFromTo[animationFrom];
            value[animationTo] = blend;
            customBlendingFromTo[animationFrom] = value; 
            //Debug.Log($"{animationFrom} -->> {animationTo} equals {blend}");
        }

        public static bool TryGetAnimationBlendValue(int animationFrom, int animationTo, out float blendReturnValue) 
        {
            float blendValue = 0f;

            if (alwaysBlendOut.TryGetValue(animationFrom, out blendValue)) {
                blendReturnValue = blendValue; 
                return true; 
            } else if (alwaysBlendIn.TryGetValue(animationTo, out blendValue)) {
                blendReturnValue = blendValue; 
                return true; 
            } 

            if (customBlendingFromTo.TryGetValue(animationFrom, out Dictionary<int, float> value)) 
            { 
                if (value.TryGetValue(animationTo, out blendValue)) 
                { 
                    blendReturnValue = blendValue; 
                    return true; 
                }
            } 

            bool fromIsBOEAnim = BunchOfEmotesSupport.Installed ? BunchOfEmotesSupport.GameAnimationIsCustomAnimation(animationFrom) : false;
            bool toIsBOEAnim = BunchOfEmotesSupport.Installed ? BunchOfEmotesSupport.GameAnimationIsCustomAnimation(animationTo) : false;

            if (fromIsBOEAnim) { blendReturnValue = BPatchTC.defaultAnimationBlendingOut.Value; }
            else if (toIsBOEAnim) { blendReturnValue = BPatchTC.defaultAnimationBlendingIn.Value; }
            else { blendReturnValue = 0f; }
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Player), nameof(Player.PlayAnim))]
        public static bool PlayAnimBlendingPrefix(int newAnim, bool forceOverwrite, bool instant, float atTime, Player __instance) 
        {
            if (__instance != WorldHandler.instance?.GetCurrentPlayer()) return true;

            if (!BPatchTC.enableAnimationBlending.Value || !__instance.gameObject.activeSelf 
            || (newAnim == __instance.curAnim && !forceOverwrite)) { return true; }

            bool isFallbackBlendValue = TryGetAnimationBlendValue(__instance.curAnim, newAnim, out var blendValue);        
            //Debug.Log($"{__instance.curAnim} -->> {newAnim} equals {blendValue} (is fallback: {isFallbackBlendValue})");    
			if (blendValue > 0 && !instant && atTime == -1f) //&& !__instance.animInfos.ContainsKey(__instance.curAnim))
			{
				__instance.anim.CrossFade(newAnim, blendValue);
                __instance.curAnimActiveTime = 0f;
                __instance.firstFrameAnim = true;
                __instance.characterVisual.feetIK = __instance.animInfos.ContainsKey(newAnim) && __instance.animInfos[newAnim].feetIK;
                __instance.curAnim = newAnim;
                return false; 
			}
            
            return true;
        }
    }

}