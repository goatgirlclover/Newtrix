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

        public static List<string> importantRules = new(); 

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
                bool importantRule = trimmedCustom.EndsWith("!"); 
                if (importantRule) { trimmedCustom = trimmedCustom.Substring(0, trimmedCustom.Length - 1); }
                try
                {
                    int colonIndex = trimmedCustom.LastIndexOf(':');
                    if (colonIndex == -1) 
                        throw new FormatException("Missing blend time separator (:)");

                    string selector = trimmedCustom.Substring(0, colonIndex);
                    string blendValueString = trimmedCustom.Substring(colonIndex + 1);

                    if (selector.Contains('|')) {
                        string[] selectors = selector.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        foreach (string miniSelector in selectors)
                            ParseSelectorValuePair(miniSelector.Trim(), blendValueString, importantRule); 
                    } else { 
                        ParseSelectorValuePair(selector, blendValueString, importantRule); 
                    }
                } catch (Exception ex) {
                    Debug.LogWarning($"(NewTrix/ABPatchesTC) Failed parsing custom animation blending string '{trimmedCustom}': {ex.Message}");
                }
            }
        }

        public static void ParseSelectorValuePair(string selector, string blendValueString, bool importantRule = false) {
            List<float> blend = new(); 
            string[] splitByArrows = selector.Split('>');

            int slashIndex = blendValueString.LastIndexOf('/');
            if (slashIndex != -1) {
                if (splitByArrows.Length == 2) { 
                    throw new FormatException($"Blend time format '{blendValueString}' invalid for selector '{selector}' - check formatting");
                }
                
                string blendValue1 = blendValueString.Substring(0, slashIndex);
                string blendValue2 = blendValueString.Substring(slashIndex + 1);
                if (float.TryParse(blendValue1, out float blend1) && float.TryParse(blendValue2, out float blend2)) {
                    blend.Add(blend1); 
                    blend.Add(blend2); 
                } else {
                    throw new FormatException($"Blend time '{blendValueString}' invalid - check formatting");
                }
            } else {
                if (!float.TryParse(blendValueString, out float blend1))
                    throw new FormatException($"Blend time '{blendValueString}' invalid - check formatting");
                blend.Add(blend1); 
            }

            switch (splitByArrows.Length)
            {
                case 1: // "animation:outBlend" (equivalent to "animation>*:blend") OR "animation:inBlend/outBlend"
                    HandleSingleAnimationRule(splitByArrows[0], blend.ToArray(), importantRule);
                    break;
                case 2: // "animation1>animation2:blend"
                    HandleTwoAnimationRule(splitByArrows[0], splitByArrows[1], blend.ToArray(), importantRule);
                    break;
                case 3: // "animation1>animation2>animation3:inOutBlend" OR "animation1>animation2>animation3:inBlend/outBlend" 
                                                                        // (equivalent to "anim1>anim2:inBlend; anim2>anim3: outBlend;)
                    HandleThreeAnimationRule(splitByArrows[0], splitByArrows[1], splitByArrows[2], blend.ToArray(), importantRule);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Improper formatting - number of arrows (>) outside of range (0-2)");
            }
        }

        private static void AlwaysBlendIn(int part, float blend) {
            if (alwaysBlendIn.ContainsKey(part)) { 
                bool currentRuleImportant = IsImportantRule("*", part.ToString(), alwaysBlendIn[part]); 
                bool newRuleImportant = IsImportantRule("*", part.ToString(), blend); 
                if ((currentRuleImportant && newRuleImportant) || !currentRuleImportant) { alwaysBlendIn[part] = blend; }
            }
            else { alwaysBlendIn[part] = blend; }
        }

        private static void AlwaysBlendOut(int part, float blend) {
            if (alwaysBlendOut.ContainsKey(part)) { 
                bool currentRuleImportant = IsImportantRule(part.ToString(), "*", alwaysBlendOut[part]); 
                bool newRuleImportant = IsImportantRule(part.ToString(), "*", blend); 
                if ((currentRuleImportant && newRuleImportant) || !currentRuleImportant) { alwaysBlendOut[part] = blend; }
            }
            else { alwaysBlendOut[part] = blend; }
        }

        private static string PartsToRule(string fromPart, string toPart, float blend) {
            return $"{fromPart}>{toPart}:{blend.ToString()}"; 
        }

        private static bool IsImportantRule(string fromPart, string toPart, float blend) {
            return IsImportantRule(PartsToRule(fromPart, toPart, blend)); 
        }

        private static bool IsImportantRule(string rule) {
            return importantRules.Contains(rule); 
        }

        private static void HandleSingleAnimationRule(string fromPart, float[] blend, bool importantRule) 
        {
            if (blend.Count() == 1) { 
                if (importantRule) { importantRules.Add(PartsToRule(fromPart, "*", blend[0])); }
                HandleSingleAnimationRuleF(fromPart, blend[0]); 
            }
            else if (blend.Count() == 2) { 
                if (importantRule) { 
                    importantRules.Add(PartsToRule("*", fromPart, blend[0]));
                    importantRules.Add(PartsToRule(fromPart, "*", blend[1])); 
                }
                HandleSingleAnimationRuleT(fromPart, blend[0]);
                HandleSingleAnimationRuleF(fromPart, blend[1]); 
            } else { throw new ArgumentOutOfRangeException("Blend value count outside of range (1-2)"); }
        }

        private static void HandleTwoAnimationRule(string fromPart, string toPart, float[] blend, bool importantRule) {
            if (importantRule) { importantRules.Add(PartsToRule(fromPart, toPart, blend[0])); }
            HandleTwoAnimationRule(fromPart, toPart, blend[0]); 
        }

        private static void HandleThreeAnimationRule(string startPart, string middlePart, string endPart, float[] blend, bool importantRule) {
            if (blend.Count() == 1) { 
                if (importantRule) {
                    importantRules.Add(PartsToRule(startPart, middlePart, blend[0]));
                    importantRules.Add(PartsToRule(middlePart, endPart, blend[0]));
                }
                HandleThreeAnimationRule(startPart, middlePart, endPart, blend[0]); 
            }
            else if (blend.Count() == 2) { 
                if (importantRule) {
                    importantRules.Add(PartsToRule(startPart, middlePart, blend[0]));
                    importantRules.Add(PartsToRule(middlePart, endPart, blend[1]));
                }
                HandleTwoAnimationRule(startPart, middlePart, blend[0]);
                HandleTwoAnimationRule(middlePart, endPart, blend[1]); 
            } else { throw new ArgumentOutOfRangeException("Blend value count outside of range (1-2)"); }
        }

        private static void HandleSingleAnimationRuleF(string fromPart, float blend)
        {
            int animationFrom = AnimationUtility.GetAnimationByName(fromPart.Trim());
            AlwaysBlendOut(animationFrom, blend);
        }

        private static void HandleSingleAnimationRuleT(string toPart, float blend) 
        {
            int animationTo = AnimationUtility.GetAnimationByName(toPart.Trim());
            AlwaysBlendIn(animationTo, blend);
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
                AlwaysBlendOut(animationFrom, blend);
            }
            else if (alwaysIn)
            {
                int animationTo = AnimationUtility.GetAnimationByName(trimmedTo);
                AlwaysBlendIn(animationTo, blend);
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
                AlwaysBlendIn(animationMiddle, blend);
                AlwaysBlendOut(animationMiddle, blend);
            }
            else if (alwaysOut)
            {
                int animationFrom = AnimationUtility.GetAnimationByName(trimmedStart);
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                AlwaysBlendOut(animationMiddle, blend);
                AddCustomBlending(animationFrom, animationMiddle, blend);
            }
            else if (alwaysIn)
            {
                int animationMiddle = AnimationUtility.GetAnimationByName(trimmedMiddle);
                int animationTo = AnimationUtility.GetAnimationByName(trimmedEnd);
                AlwaysBlendIn(animationMiddle, blend);
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

            if (value.ContainsKey(animationTo)) { 
               string originalRule = PartsToRule(animationFrom.ToString(), animationTo.ToString(), value[animationTo]); 
               string newRule = PartsToRule(animationFrom.ToString(), animationTo.ToString(), blend); 
               if (IsImportantRule(originalRule) && !IsImportantRule(newRule)) { return; }
            }

            value[animationTo] = blend;
            customBlendingFromTo[animationFrom] = value;
            //Debug.Log($"{animationFrom} -->> {animationTo} equals {blend}");
        }

        public static bool TryGetAnimationBlendValue(int animationFrom, int animationTo, out float blendReturnValue) 
        {
            bool hasAlwaysOut = alwaysBlendOut.TryGetValue(animationFrom, out float blendValueOut);
            bool hasAlwaysIn = alwaysBlendIn.TryGetValue(animationTo, out float blendValueIn);
            string outRule = PartsToRule(animationFrom.ToString(), "*", blendValueOut); 
            string inRule = PartsToRule("*", animationTo.ToString(), blendValueIn);

            if (hasAlwaysOut) {
                if (!(hasAlwaysIn && IsImportantRule(inRule) && !IsImportantRule(outRule))) { 
                    blendReturnValue = blendValueOut; 
                    return true; 
                }
            } 

            if (hasAlwaysIn) {
                if (!(hasAlwaysOut && IsImportantRule(outRule) && !IsImportantRule(inRule))) { 
                    blendReturnValue = blendValueIn; 
                    return true; 
                }
            } 

            if (customBlendingFromTo.TryGetValue(animationFrom, out Dictionary<int, float> value)) 
            { 
                if (value.TryGetValue(animationTo, out float blendValue)) 
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

            bool isFallbackBlendValue = !TryGetAnimationBlendValue(__instance.curAnim, newAnim, out var blendValue);  
            bool isImportantRule = IsImportantRule(__instance.curAnim.ToString(), newAnim.ToString(), blendValue);   
			if ((blendValue > 0 || !isFallbackBlendValue) && (!instant || isImportantRule) && atTime == -1f)
			{
				__instance.anim.CrossFade(newAnim, blendValue);
                __instance.curAnimActiveTime = 0f;
                __instance.firstFrameAnim = true;
                __instance.characterVisual.feetIK = __instance.animInfos.ContainsKey(newAnim) && __instance.animInfos[newAnim].feetIK;
                __instance.curAnim = newAnim;
                return false; 
			}
            
            //Debug.Log($"{__instance.curAnim} -->> {newAnim} equals {blendValue} (is fallback: {isFallbackBlendValue})");    
            return true;
        }
    }

}