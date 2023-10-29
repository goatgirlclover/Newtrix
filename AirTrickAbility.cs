using BepInEx;
using HarmonyLib;
using Reptile;
using System;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.0.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class ATAPatchTC
    {
        [HarmonyPatch(typeof(AirTrickAbility), nameof(AirTrickAbility.SetupBoostTrick))]
        [HarmonyPostfix]
        private static void AirBoostTrickPOF(AirTrickAbility __instance)
        {
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    __instance.p.DoTrick(Player.TrickType.AIR_BOOST, "McTwist", __instance.curTrick);
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash("jumpTrick1"), true, false, 0f);
                    __instance.p.DoTrick(Player.TrickType.AIR_BOOST, "Corkscrew", __instance.curTrick);
                }
            }
        }
    }
}