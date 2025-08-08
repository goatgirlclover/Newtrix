using System;
using HarmonyLib;
using Reptile;
using trickyclown;
using UnityEngine;

namespace newtrickx
{
    [HarmonyPatch(typeof(VertAbility))]
    internal class VertAbilityPatches2
    {
        [HarmonyPatch("StartTrick")]
        [HarmonyPrefix]
        public static bool StartTrick_Prefix(VertAbility __instance)
        {
            string skateboardAirBoostTrick0 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick0cfg");
            string skateboardAirBoostTrick1 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick1cfg");
            string skateboardAirBoostTrick2 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick2cfg");

            string inlineAirBoostTrick0 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick0cfg");
            string inlineAirBoostTrick1 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick1cfg");
            string inlineAirBoostTrick2 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick2cfg");

            string bmxAirBoostTrick0 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick0cfg");
            string bmxAirBoostTrick1 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick1cfg");
            string bmxAirBoostTrick2 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick2cfg");

            string footAirBoostTrick0 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick0cfg");
            string footAirBoostTrick1 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick1cfg");
            string footAirBoostTrick2 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick2cfg");

            AirTrickAbility airTrickAbility = __instance.p.airTrickAbility;
            airTrickAbility.curTrick = __instance.p.InputToTrickNumber();
            Console.WriteLine("incheckboosttrick with value " + __instance.p.moveStyle.ToString());
            bool getTonyCfg = ATAPatchTC.GetTonyCfg();
            bool flag = __instance.p.CheckBoostTrick();
            bool result;
            if (flag)
            {

                if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    if (airTrickAbility.curTrick == 0)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirBoostTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirBoostTrick0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 1)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirBoostTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirBoostTrick1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 2)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirBoostTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirBoostTrick2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    if (airTrickAbility.curTrick == 0)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirBoostTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirBoostTrick0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 1)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirBoostTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirBoostTrick1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 2)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirBoostTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirBoostTrick2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    if (airTrickAbility.curTrick == 0)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirBoostTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirBoostTrick0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 1)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirBoostTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirBoostTrick1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (airTrickAbility.curTrick == 2)
                    {
                        ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirBoostTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirBoostTrick2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }

                //MOVESTYLER FIX
                if (VertAbilityPatches.nonVanillaMovestyle)
                {
                    __instance.p.PlayAnim(airTrickAbility.airBoostTrickHashes[airTrickAbility.curTrick], true, false, 0f);
                }
                __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                __instance.trickScoreBuffered = true;
                __instance.trickTimer = __instance.trickDuration * 1.5f;
                __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);
                __instance.trickType = AirTrickAbility.TrickType.BOOST_TRICK;
                result = false;
            }
            else
            {
                __instance.p.PlayAnim(airTrickAbility.airTrickHashes[airTrickAbility.curTrick], false, false, -1f);

                string skateboardAirTrick0 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick0cfg");
                string skateboardAirTrick1 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick1cfg");
                string skateboardAirTrick2 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick2cfg");

                string inlineAirTrick0 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick0cfg");
                string inlineAirTrick1 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick1cfg");
                string inlineAirTrick2 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick2cfg");

                string bmxAirTrick0 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick0cfg");
                string bmxAirTrick1 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick1cfg");
                string bmxAirTrick2 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick2cfg");

                string footAirTrick0 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick0cfg");
                string footAirTrick1 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick1cfg");
                string footAirTrick2 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick2cfg");

                __instance.p.PlayAnim(airTrickAbility.airTrickHashes[airTrickAbility.curTrick], true, false, 0f);
                bool flag0 = __instance.p.moveStyle == MoveStyle.SKATEBOARD || __instance.p.moveStyle == MoveStyle.SPECIAL_SKATEBOARD;
                if (flag0)
                {
                    airTrickAbility.duration = airTrickAbility.skateboardTrickDuration;
                }
                else
                {
                    bool flag2 = __instance.p.moveStyle == MoveStyle.BMX;
                    if (flag2)
                    {
                        airTrickAbility.duration = airTrickAbility.bmxTrickDuration;
                    }
                    else
                    {
                        bool flag3 = __instance.p.moveStyle == MoveStyle.INLINE;
                        if (flag3)
                        {
                            airTrickAbility.duration = airTrickAbility.inlineTrickDuration;
                        }
                    }
                }
                bool flag4 = __instance.p.CheckBoostTrick();
                if (flag4)
                {
                    airTrickAbility.SetupBoostTrick();
                }
                else
                {
                    __instance.p.PlayAnim(airTrickAbility.airTrickHashes[airTrickAbility.curTrick], true, false, 0f);

                    if (__instance.p.moveStyle == MoveStyle.BMX)
                    {
                        if (airTrickAbility.curTrick == 0)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirTrick0cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirTrick0), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["bmxAirTrick0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (airTrickAbility.curTrick == 1)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirTrick1cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirTrick1), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["bmxAirTrick1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (airTrickAbility.curTrick == 2)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["bmxAirTrick2cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(bmxAirTrick2), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["bmxAirTrick2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    else if (__instance.p.moveStyle == MoveStyle.INLINE)
                    {
                        if (airTrickAbility.curTrick == 0)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirTrick0cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirTrick0), true, false, -1f);
                            if (ATAPatchTC.IdleOverrides["inlineAirTrick0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (airTrickAbility.curTrick == 1)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirTrick1cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirTrick1), true, false, -1f);
                            if (ATAPatchTC.IdleOverrides["inlineAirTrick1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (airTrickAbility.curTrick == 2)
                        {
                            ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["inlineAirTrick2cfgAnim"]);

                            __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(inlineAirTrick2), true, false, -1f);
                            if (ATAPatchTC.IdleOverrides["inlineAirTrick2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    else if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                    {
                        bool enableTonyCfg = ATAPatchTC.enableTonyCfg.Value;
                        if (airTrickAbility.curTrick == 0)
                        {
                            float moveAxisX = __instance.p.moveAxisX;
                            float moveAxisY = __instance.p.moveAxisY;
                            if (enableTonyCfg)
                            {
                                if (moveAxisX <= -0.25f)
                                {
                                    if (moveAxisY <= -0.25f || moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick0), true, false, -1f);
                                        if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                        { VertAbilityPatches.overridingIdle = true; }
                                        else
                                        { VertAbilityPatches.overridingIdle = false; }
                                    }
                                    else
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("groundTrick0"), true, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                                else if (moveAxisX >= 0.25f)
                                {
                                    if (moveAxisY <= -0.25f || moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick0), true, false, -1f);
                                        if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                        { VertAbilityPatches.overridingIdle = true; }
                                        else
                                        { VertAbilityPatches.overridingIdle = false; }
                                    }
                                    else
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("groundTrick2"), true, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                                else if (moveAxisY <= -0.25f)
                                {
                                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("grindTrick0"), true, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                                else if (moveAxisY >= 0.25f)
                                {
                                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("groundTrick3"), true, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                                else //NO TILT 0
                                {
                                    ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirTrick0cfgAnim"]);

                                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick0), true, false, -1f);
                                    if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                    { VertAbilityPatches.overridingIdle = true; }
                                    else
                                    { VertAbilityPatches.overridingIdle = false; }
                                }
                            }
                            else //NEUTRAL 0
                            {
                                ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirTrick0cfgAnim"]);

                                __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick0), true, false, -1f);
                                if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                { VertAbilityPatches.overridingIdle = true; }
                                else
                                { VertAbilityPatches.overridingIdle = false; }
                            }
                        }
                        else if (airTrickAbility.curTrick == 1)
                        {
                            if (enableTonyCfg && __instance.p.slideButtonHeld)
                            {
                                __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("groundBoostTrick0"), false, false, -1f);
                                VertAbilityPatches.overridingIdle = false;
                            }
                            else //TRIANGLE NO SLIDE
                            {
                                ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirTrick1cfgAnim"]);

                                __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick1), false, false, -1f);
                                if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                { VertAbilityPatches.overridingIdle = true; }
                                else
                                { VertAbilityPatches.overridingIdle = false; }
                            }
                        }
                        else if (airTrickAbility.curTrick == 2)
                        {
                            if (enableTonyCfg)
                            {
                                if (__instance.p.moveAxisX >= 0.25f)
                                {
                                    if (__instance.p.moveAxisY <= -0.25f && BunchOfEmotesSupport.Installed)
                                    {
                                        ATAPatchTC.CheckAnimOverride(true);
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("christ air"), false, false, -1f);
                                        VertAbilityPatches.overridingIdle = false;
                                    }
                                    else if (__instance.p.moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick2), false, false, -1f);
                                        if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                        { VertAbilityPatches.overridingIdle = true; }
                                        else
                                        { VertAbilityPatches.overridingIdle = false; }
                                    }
                                    else
                                    {
                                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName("airTrick1"), false, false, -1f);
                                        VertAbilityPatches.overridingIdle = false;
                                    }
                                }
                                else //2 NO TILT
                                {
                                    ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirTrick2cfgAnim"]);

                                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick2), false, false, -1f);
                                    if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                    { VertAbilityPatches.overridingIdle = true; }
                                    else
                                    { VertAbilityPatches.overridingIdle = false; }
                                }
                            }
                            else //2 NEUTRAL
                            {
                                ATAPatchTC.CheckAnimOverride(ATAPatchTC.IdleOverrides["skateboardAirTrick2cfgAnim"]);

                                __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(skateboardAirTrick2), false, false, -1f);
                                if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                { VertAbilityPatches.overridingIdle = true; }
                                else
                                { VertAbilityPatches.overridingIdle = false; }
                            }
                        }
                    }

                    //MOVESTYLER FIX
                    else if (VertAbilityPatches.nonVanillaMovestyle)
                    {
                        __instance.p.PlayAnim(airTrickAbility.airTrickHashes[airTrickAbility.curTrick], true, false, 0f);
                    }
                }
                    __instance.trickScoreBuffered = true;
                __instance.trickTimer = __instance.trickDuration;
                __instance.trickType = AirTrickAbility.TrickType.VERT_TRICK;
                result = false;
            }
            return result;
        }
    }
}
