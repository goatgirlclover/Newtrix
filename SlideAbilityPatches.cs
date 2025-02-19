using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Reptile;
using UnityEngine;

namespace newtrickx
{
    [BepInPlugin("ConfigTrixSlidesAndManuals", "New Trix Slides", "1.4.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    internal class SlideAbilityPatches : BaseUnityPlugin
    {
        public static SlideAbilityPatches Instance { get; private set; }

        private void Awake()
        {
            SlideAbilityPatches.Instance = this;
            this.configEntriesSlide = new Dictionary<string, ConfigEntry<string>>();
            this.configEntriesSlide["slideSkateboardCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideSkateboardCfg", "roll", "Skateboard Manual");
            this.configEntriesSlide["slideSkateboardNameCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideSkateboardCfgName", "Manual", "Skateboard Manual Name");
            this.configEntriesSlide["slideFootCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideFootCfg", "softBounce17", "On-foot Roll/Slide");
            this.configEntriesSlide["slideFootNameCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideFootCfgName", "Check your configs >:3c", "On-foot Roll/Slide Name");
            this.configEntriesSlide["slideInlineCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideInlineCfg", "roll", "Inline Slide");
            this.configEntriesSlide["slideInlineNameCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideInlineCfgName", "Cess Slide", "Inline Slide Name");
            this.configEntriesSlide["slideBmxCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideBmxCfg", "roll", "BMX Manual");
            this.configEntriesSlide["slideBmxNameCfg"] = base.Config.Bind<string>("Manual/Slide/Roll", "slideBmxCfgName", "Manual", "BMX Manual Name");
        }

        public string GetConfigValueSlide(string key)
        {
            ConfigEntry<string> configEntry;
            bool flag = this.configEntriesSlide.TryGetValue(key, out configEntry);
            string result;
            if (flag)
            {
                result = configEntry.Value;
            }
            else
            {
                base.Logger.LogError("Config key '" + key + "' not found.");
                result = null;
            }
            return result;
        }

        [HarmonyPatch(typeof(SlideAbility), "OnStartAbility")]
        [HarmonyPrefix]
        public static bool OnStartAbility_Prefix(SlideAbility __instance)
        {
            string configValueSlide = SlideAbilityPatches.Instance.GetConfigValueSlide("slideSkateboardCfg");
            string configValueSlide2 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideSkateboardNameCfg");
            string configValueSlide3 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideFootCfg");
            string configValueSlide4 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideFootNameCfg");
            string configValueSlide5 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideInlineCfg");
            string configValueSlide6 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideInlineNameCfg");
            string configValueSlide7 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideBmxCfg");
            string configValueSlide8 = SlideAbilityPatches.Instance.GetConfigValueSlide("slideBmxNameCfg");
            Console.WriteLine(__instance.p.currentTrickName);
            __instance.setSpeedOnHittingBreakable = (__instance.baseSpeed = __instance.p.maxMoveSpeed);
            __instance.singleBoostCooldown = 0f;
            __instance.normalCapsuleHeight = __instance.p.motor.GetCapsule().height;
            __instance.normalCapsuleCenter = __instance.p.motor.GetCapsule().center.y;
            __instance.autoAirTrickFromLauncher = false;
            __instance.wantToStop = (__instance.stopDecided = false);
            bool flag = __instance.p.moveStyle == MoveStyle.ON_FOOT;
            bool flag2 = flag;
            bool flag3 = flag2;
            if (flag3)
            {
                __instance.trickName = configValueSlide4;
                __instance.rollHash = Animator.StringToHash(configValueSlide3);
                __instance.Crouch(true);
            }
            else
            {
                bool flag4 = __instance.p.moveStyle == MoveStyle.SKATEBOARD;
                bool flag5 = flag4;
                bool flag6 = flag5;
                if (flag6)
                {
                    __instance.trickName = configValueSlide2;
                    __instance.rollHash = Animator.StringToHash(configValueSlide);
                }
                else
                {
                    bool flag7 = __instance.p.moveStyle == MoveStyle.INLINE;
                    bool flag8 = flag7;
                    bool flag9 = flag8;
                    if (flag9)
                    {
                        __instance.trickName = configValueSlide6;
                        __instance.rollHash = Animator.StringToHash(configValueSlide5);
                    }
                    else
                    {
                        bool flag10 = __instance.p.moveStyle == MoveStyle.BMX;
                        bool flag11 = flag10;
                        bool flag12 = flag11;
                        if (flag12)
                        {
                            __instance.trickName = configValueSlide8;
                            __instance.rollHash = Animator.StringToHash(configValueSlide7);
                        }
                    }
                }
            }
            __instance.SetSlideState(SlideAbility.SlideState.ROLL);
            bool flag19 = __instance.p.lastElevationForSlideBoost > __instance.p.tf.position.y + 0.5f;
            bool flag20 = flag19;
            bool flag21 = flag20;
            if (flag21)
            {
                __instance.SingleBoost(__instance.p.boostSpeed - 1f);
            }
            return false;
        }

        private Dictionary<string, ConfigEntry<string>> configEntriesSlide;
    }
}
