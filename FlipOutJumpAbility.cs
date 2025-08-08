//using BepInEx;
//using HarmonyLib;
//using Reptile;
//using System;
//using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

//namespace trickyclown
//{
//    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.2.0")]
//    [BepInProcess("Bomb Rush Cyberfunk.exe")]
//    public class FOJPatchTC
//    {
//        [HarmonyPatch(typeof(FlipOutJumpAbility), nameof(FlipOutJumpAbility.OnStartAbility))]
//        [HarmonyPrefix]
//        private static bool OnStartAbilityPrefix(FlipOutJumpAbility __instance)
//        {
//            __instance.p.SetDustEmission(0);
//            string trickName;
//            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
//            {
//                trickName = __instance.skateboardTrickName;
//                __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(jumpInline), false, false, -1f);
//            }
//            else if (__instance.p.moveStyle == MoveStyle.BMX)
//            {
//                trickName = __instance.bmxTrickName;
//            }
//            else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
//            {
//                trickName = "Kick The Moon";
//            }
//            else
//            {
//                trickName = __instance.inlineTrickName;
//            }
//            __instance.p.DoTrick(Player.TrickType.POLE_FLIP, trickName, 0);
//            return false;
//        }
//    }
//}