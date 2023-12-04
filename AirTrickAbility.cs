using BepInEx;
using HarmonyLib;
using Reptile;
using System;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

namespace trickyclown
{
    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.1.4")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class ATAPatchTC
    {
        [HarmonyPatch(typeof(AirTrickAbility), nameof(AirTrickAbility.Init))]
        [HarmonyPrefix]
        private static bool Init_Prefix(AirTrickAbility __instance)
        {
            __instance.skateboardTrickNames = new string[] { "Backside 360 Varial", "Backflip Indy", "Method Grab", "1080", "McTwist", "1080" };
            __instance.inlineTrickNames = new string[] { "Cork 720", "Method Grab", "Abstract 360", "1080 California Roll", "Flying Fish", "Corkscrew" };
            __instance.bmxTrickNames = new string[] { "Tailwhip 360", "No Hand Backflip", "Superman Seat Grab Indian", "720 Double Backflip", "Barrel 90", "360 Backflip" };
            __instance.trickingTrickNames = new string[] { "Bullet Spin", "Backflip Grab", "Cheat 720", "Shuriken", "Corkscrew", "Shuriken" };
            return true;
        }

        [HarmonyPatch(typeof(AirTrickAbility), nameof(AirTrickAbility.SetupBoostTrick))]
        [HarmonyPrefix]
        private static bool SetupBoostTrick_Prefix(AirTrickAbility __instance)
        {
            Console.WriteLine("MC TWIST");
            __instance.p.PlayAnim(__instance.airBoostTrickHashes[__instance.curTrick], true, false, 0f);
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                }
                //else if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick2"), true, false, 0f);
                //}
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("airTrick3"), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                }
                //if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick2"), true, false, 0f);
                //}
            }
            if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("hitBounce"), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                }
                //    if (__instance.curTrick == 2)
                //    {
                //        __instance.p.PlayAnim(Animator.StringToHash("airTrick4BMX"), true, false, 0f);
                //    }
            }
            else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                }
                //if (__instance.curTrick == 2)
                //{
                //    __instance.p.PlayAnim(Animator.StringToHash("sitLegsCrossed"), true, false, 0f);
                //}
            }

            __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
            __instance.p.ringParticles.Emit(1);
            __instance.trickType = AirTrickAbility.TrickType.BOOST_TRICK;
            __instance.duration *= 1.5f;
            if (!__instance.p.isAI)
            {
                __instance.p.SetForwardSpeed(__instance.p.boostSpeed);
            }
            __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);
            return false;
        }
    }
}