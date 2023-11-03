using BepInEx;
using HarmonyLib;
using Reptile;
using System;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.0.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class GTAPatchTC
    {
        [HarmonyPatch(typeof(GroundTrickAbility), nameof(GroundTrickAbility.Init))]
        [HarmonyPrefix]
        private static bool Init_Prefix(GroundTrickAbility __instance)
        {
            __instance.skateboardTrickNames = new string[] { "Kickflip", "Backside 360 Powerspin", "360 Flip", "Handstand Flip", "Switch FS 180 Front Foot Impossible", "Handstand Flip" };
            __instance.inlineSkatesTrickNames = new string[] { "Unity Spin Cess Slide", "Duckwalk Fakie", "Back Closed Tree", "Bio", "One Foot", "Bio" };
            return true;
        }


        [HarmonyPatch(typeof(GroundTrickAbility), nameof(GroundTrickAbility.DoBoostTrick))]
        [HarmonyPrefix]
        private static bool DoBoostTrick_Prefix(GroundTrickAbility __instance)
        {
            __instance.p.PlayAnim(__instance.groundBoostTrickHashes[__instance.curTrick], true, false, 0f);
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, 0f);

                }

                //if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("groundTrick4"), true, false, 0f);
                    
                //}
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, 0f);

                }
                //if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("groundTrick4"), true, false, 0f);
                    
                //}
            }
            else if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                //if (__instance.curTrick == 1)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, 0f);

                //}
                //if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("groundTrick4"), true, false, 0f);
                    
                //}
            }
            __instance.boostTrick = true;
            __instance.p.ringParticles.Emit(1);
            __instance.duration *= 1.8f;
            if (!__instance.p.isAI)
            {
                __instance.p.SetForwardSpeed(__instance.p.boostSpeed);
            }
            __instance.p.DoTrick(Player.TrickType.GROUND_BOOST, __instance.GetTrickName(__instance.curTrick, true), __instance.curTrick);
            __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
            __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);
            return false;
        }
    }
}