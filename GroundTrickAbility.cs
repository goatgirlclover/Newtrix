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
        [HarmonyPatch(typeof(GroundTrickAbility), nameof(GroundTrickAbility.DoBoostTrick))]
        [HarmonyPostfix]
        private static void GroundBoostTrickPOF(GroundTrickAbility __instance)
        {
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, 0f);
                    __instance.p.DoTrick(Player.TrickType.GROUND_BOOST, "Switch FS 180 Front Foot Impossible", __instance.curTrick);
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, 0f);
                    __instance.p.DoTrick(Player.TrickType.GROUND_BOOST, "One Foot", __instance.curTrick);
                }
            }
        }
    }
}