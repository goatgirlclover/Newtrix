using HarmonyLib;
using Reptile;
using System;
using UnityEngine;

namespace newtrickx
{
    [HarmonyPatch(typeof(VertAbility))]
    internal class VertAbilityPatches
    {

        [HarmonyPatch(nameof(VertAbility.StartTrick))]
        [HarmonyPrefix]
        public static bool StartTrick_Prefix(VertAbility __instance)
        {
            AirTrickAbility airTrickAbility = __instance.p.airTrickAbility;
            airTrickAbility.curTrick = __instance.p.InputToTrickNumber();
            Console.WriteLine("incheckboosttrick with value " + __instance.p.moveStyle);
            if (__instance.p.CheckBoostTrick())
            {
                __instance.p.PlayAnim(airTrickAbility.airBoostTrickHashes[airTrickAbility.curTrick], false, false, -1f);
                if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    if (airTrickAbility.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    }
                    //else if (airTrickAbility.curTrick == 2)
                    //{
                    //    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick2"), true, false, 0f);
                    //}
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    if (airTrickAbility.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("airTrick3"), true, false, 0f);
                    }
                    if (airTrickAbility.curTrick == 2)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    }
                }
                if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    if (airTrickAbility.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("hitBounce"), true, false, 0f);
                    }
                    if (airTrickAbility.curTrick == 2)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    if (airTrickAbility.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    }
                    //if (airTrickAbility.curTrick == 2)
                    //{
                    //    __instance.p.PlayAnim(Animator.StringToHash("sitLegsCrossed"), true, false, 0f);
                    //}
                }
                __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                __instance.trickScoreBuffered = true;
                __instance.trickTimer = __instance.trickDuration * 1.5f;
                __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);
                __instance.trickType = AirTrickAbility.TrickType.BOOST_TRICK;
                return false;
            }
            __instance.p.PlayAnim(airTrickAbility.airTrickHashes[airTrickAbility.curTrick], false, false, -1f);
            __instance.trickScoreBuffered = true;
            __instance.trickTimer = __instance.trickDuration;
            __instance.trickType = AirTrickAbility.TrickType.VERT_TRICK;
            return true;
        }
    }
}