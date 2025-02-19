using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Reptile;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("ConfigTrixGrindTricks", "New Trix Grinds", "1.4.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]

    public class GriTAPatchTC : BaseUnityPlugin
    {
        public static GriTAPatchTC Instance { get; private set; }

        private Dictionary<string, ConfigEntry<string>> configEntries;

        [HarmonyPatch(typeof(GrindAbility), nameof(GrindAbility.FixedUpdateAbility))]
        [HarmonyPostfix]
        private static void FixedUpdateAbilityPRF(GrindAbility __instance)
        {
            VertAbilityPatches.overridingIdle = false;
        }

            void Awake()
        {
            Instance = this;

            configEntries = new Dictionary<string, ConfigEntry<string>>
            {
                //Foot
                { "footStartGrindTrickcfg", Config.Bind("On-foot Grind Tricks", "Foot Switch Trick (Unused?)", "switchToEquippedMovestyleGrind",
                "Switch trick") },
                { "footStartGrindTrick2cfg", Config.Bind("On-foot Grind Tricks", "Foot Start Trick", "grindTrick3",
                "Start trick") },
                { "footStartGrindTrickNamecfg", Config.Bind("On-foot Grind Tricks", "Foot Switch Trick Name", "",
                "Switch trick name") },
                { "footStartGrindTrick2Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Start Trick Name", "Valdez",
                "Start trick name") },
                { "footGrindTrick0cfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 0", "grindTrick0",
                "Button 1 trick") },
                //{ "footGrindTrick0Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 0 Name", "Hook Kick",
                //"Button 1 trick name") },
                { "footGrindTrick1cfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 1", "grindTrick1",
                "Button 2 trick") },
                //{ "footGrindTrick1Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 1 Name", "Cartwheel",
                //"Button 2 trick name") },
                { "footGrindTrick2cfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 2", "grindTrick2",
                "Button 3 trick") },
                //{ "footGrindTrick2Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Trick 2 Name", "Sweep Kick",
                //"Button 3 trick name") },
                { "footGrindBoostTrick0cfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 0", "grindBoostTrick0",
                "Button 1 boost trick") },
                { "footGrindBoostTrick0Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 0 Name", "Cartwheel",
                "Button 1 boost trick name") },
                { "footGrindBoostTrick1cfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 1 + Boost Start Trick", "grindBoostTrick1",
                "Button 2 boost trick") },
                { "footGrindBoostTrick1Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 1 Name", "Back Sweep",
                "Button 2 boost trick name") },
                { "footGrindBoostTrick2cfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 2", "grindBoostTrick2",
                "Button 3 boost trick") },
                { "footGrindBoostTrick2Namecfg", Config.Bind("On-foot Grind Tricks", "Foot Boost Trick 2 Name", "Hook Kick",
                "Button 3 boost trick name") },
                                //Inline
                { "inlineStartGrindTrickcfg", Config.Bind("Inline Grind Tricks", "Inline Switch Trick", "switchToEquippedMovestyleGrind",
                "Switch trick") },
                { "inlineStartGrindTrick2cfg", Config.Bind("Inline Grind Tricks", "Inline Start Trick", "grindTrick3",
                "Start trick") },
                { "inlineStartGrindTrickNamecfg", Config.Bind("Inline Grind Tricks", "Inline Switch Trick Name", "360 Frontside Grind",
                "Switch trick name") },
                { "inlineStartGrindTrick2Namecfg", Config.Bind("Inline Grind Tricks", "Inline Start Trick Name", "Soul Grind",
                "Start trick name") },
                { "inlineGrindTrick0cfg", Config.Bind("Inline Grind Tricks", "Inline Trick 0", "grindTrick0",
                "Button 1 trick") },
                //{ "inlineGrindTrick0Namecfg", Config.Bind("Inline Grind Tricks", "Inline Trick 0 Name", "Bullet Spin",
                //"Button 1 trick name") },
                { "inlineGrindTrick1cfg", Config.Bind("Inline Grind Tricks", "Inline Trick 1", "grindTrick1",
                "Button 2 trick") },
                //{ "inlineGrindTrick1Namecfg", Config.Bind("Inline Grind Tricks", "Inline Trick 1 Name", "Backflip Grab",
                //"Button 2 trick name") },
                { "inlineGrindTrick2cfg", Config.Bind("Inline Grind Tricks", "Inline Trick 2", "grindTrick2",
                "Button 3 trick") },
                //{ "inlineGrindTrick2Namecfg", Config.Bind("Inline Grind Tricks", "Inline Trick 2 Name", "Cheat 720",
                //"Button 3 trick name") },
                { "inlineGrindBoostTrick0cfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 0", "grindBoostTrick0",
                "Button 1 boost trick") },
                { "inlineGrindBoostTrick0Namecfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 0 Name", "Topside Pornstar",
                "Button 1 boost trick name") },
                { "inlineGrindBoostTrick1cfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 1 + Boost Start Trick", "grindBoostTrick1",
                "Button 2 boost trick") },
                { "inlineGrindBoostTrick1Namecfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 1 Name", "Topside Pornstar",
                "Button 2 boost trick name") },
                { "inlineGrindBoostTrick2cfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 2", "grindBoostTrick2",
                "Button 3 boost trick") },
                { "inlineGrindBoostTrick2Namecfg", Config.Bind("Inline Grind Tricks", "Inline Boost Trick 2 Name", "Topside Pornstar",
                "Button 3 boost trick name") },
                                //Skateboard
                { "skateboardStartGrindTrickcfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Switch Trick", "switchToEquippedMovestyleGrind",
                "Switch trick") },
                { "skateboardStartGrindTrick2cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Start Trick", "grindTrick3",
                "Start trick") },
                { "skateboardStartGrindTrickNamecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Switch Trick Name", "Caveman",
                "Switch trick name") },
                { "skateboardStartGrindTrick2Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Start Trick Name", "Frontside 50-50",
                "Start trick name") },
                { "skateboardGrindTrick0cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 0", "grindTrick0",
                "Button 1 trick") },
                //{ "skateboardGrindTrick0Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 0 Name", "Bullet Spin",
                //"Button 1 trick name") },
                { "skateboardGrindTrick1cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 1", "grindTrick1",
                "Button 2 trick") },
                //{ "skateboardGrindTrick1Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 1 Name", "Backflip Grab",
                //"Button 2 trick name") },
                { "skateboardGrindTrick2cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 2", "grindTrick2",
                "Button 3 trick") },
                //{ "skateboardGrindTrick2Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Trick 2 Name", "Cheat 720",
                //"Button 3 trick name") },
                { "skateboardGrindBoostTrick0cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 0", "grindBoostTrick0",
                "Button 1 boost trick") },
                { "skateboardGrindBoostTrick0Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 0 Name", "Kickflip Darkslide",
                "Button 1 boost trick name (vanilla is \"Darkslide\")") },
                { "skateboardGrindBoostTrick1cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 1 + Boost Start Trick", "screwSpin",
                "Button 2 boost trick (vanilla is \"grindBoostTrick1\")") },
                { "skateboardGrindBoostTrick1Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 1 Name", "Natas Spin (Grind)",
                "Button 2 boost trick name (vanilla is \"Darkslide\")") },
                { "skateboardGrindBoostTrick2cfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 2", "grindBoostTrick2",
                "Button 3 boost trick") },
                { "skateboardGrindBoostTrick2Namecfg", Config.Bind("Skateboard Grind Tricks", "Skateboard Boost Trick 2 Name", "Kickflip Darkslide",
                "Button 3 boost trick name (vanilla is \"Darkslide\")") },
                                //BMX
                { "bmxStartGrindTrickcfg", Config.Bind("BMX Grind Tricks", "BMX Switch Trick", "switchToEquippedMovestyleGrind",
                "Switch trick") },
                { "bmxStartGrindTrick2cfg", Config.Bind("BMX Grind Tricks", "BMX Start Trick", "grindTrick3",
                "Start trick") },
                { "bmxStartGrindTrickNamecfg", Config.Bind("BMX Grind Tricks", "BMX Switch Trick Name", "Whiplash Icepick",
                "Switch trick name (vanilla is \"Whiplash Double Peg Grind\")") },
                { "bmxStartGrindTrick2Namecfg", Config.Bind("BMX Grind Tricks", "BMX Start Trick Name", "Double Peg Grind",
                "Start trick name") },
                { "bmxGrindTrick0cfg", Config.Bind("BMX Grind Tricks", "BMX Trick 0", "grindTrick0",
                "Button 1 trick") },
                //{ "bmxGrindTrick0Namecfg", Config.Bind("BMX Grind Tricks", "BMX Trick 0 Name", "Bullet Spin",
                //"Button 1 trick name") },
                { "bmxGrindTrick1cfg", Config.Bind("BMX Grind Tricks", "BMX Trick 1", "grindTrick1",
                "Button 2 trick") },
                //{ "bmxGrindTrick1Namecfg", Config.Bind("BMX Grind Tricks", "BMX Trick 1 Name", "Backflip Grab",
                //"Button 2 trick name") },
                { "bmxGrindTrick2cfg", Config.Bind("BMX Grind Tricks", "BMX Trick 2", "grindTrick2",
                "Button 3 trick") },
                //{ "bmxGrindTrick2Namecfg", Config.Bind("BMX Grind Tricks", "BMX Trick 2 Name", "Cheat 720",
                //"Button 3 trick name") },
                { "bmxGrindBoostTrick0cfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 0", "grindBoostTrick0",
                "Button 1 boost trick") },
                { "bmxGrindBoostTrick0Namecfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 0 Name", "Backyard Grind",
                "Button 1 boost trick name") },
                { "bmxGrindBoostTrick1cfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 1 + Boost Start Trick", "grindBoostTrick1",
                "Button 2 boost trick") },
                { "bmxGrindBoostTrick1Namecfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 1 Name", "Backyard Grind",
                "Button 2 boost trick name") },
                { "bmxGrindBoostTrick2cfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 2", "grindBoostTrick2",
                "Button 3 boost trick") },
                { "bmxGrindBoostTrick2Namecfg", Config.Bind("BMX Grind Tricks", "BMX Boost Trick 2 Name", "Backyard Grind",
                "Button 3 boost trick name") }
            };
        }

        public string GetConfigValueGrind(string key)
        {
            if (configEntries.TryGetValue(key, out var entry))
            {
                return entry.Value;
            }
            else
            {
                Logger.LogWarning($"Configuration key '{key}' not found.");
                return null;
            }
        }
        [HarmonyPatch(typeof(GrindAbility), nameof(GrindAbility.DoBoostTrick))]
        [HarmonyPrefix]
        private static bool GrindBoostTrickPRF(GrindAbility __instance)
        {

            string configValueFootGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick0Namecfg");
            string configValueFootGrindName6 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick1Namecfg");
            string configValueFootGrindName7 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick2Namecfg");

            string configValueFootGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick0cfg");
            string configValueFootGrind6 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick1cfg");
            string configValueFootGrind7 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindBoostTrick2cfg");

            string configValueInlineGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick0Namecfg");
            string configValueInlineGrindName6 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick1Namecfg");
            string configValueInlineGrindName7 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick2Namecfg");

            string configValueInlineGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick0cfg");
            string configValueInlineGrind6 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick1cfg");
            string configValueInlineGrind7 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindBoostTrick2cfg");

            string configValueSkateboardGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick0Namecfg");
            string configValueSkateboardGrindName6 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick1Namecfg");
            string configValueSkateboardGrindName7 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick2Namecfg");

            string configValueSkateboardGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick0cfg");
            string configValueSkateboardGrind6 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick1cfg");
            string configValueSkateboardGrind7 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindBoostTrick2cfg");

            string configValueBMXGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick0Namecfg");
            string configValueBMXGrindName6 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick1Namecfg");
            string configValueBMXGrindName7 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick2Namecfg");

            string configValueBMXGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick0cfg");
            string configValueBMXGrind6 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick1cfg");
            string configValueBMXGrind7 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindBoostTrick2cfg");

            __instance.curTrickBoost = true;
            __instance.p.ringParticles.Emit(1);
            __instance.trickTimer = (__instance.curTrickDuration = __instance.trickStandardDuration * 1.8f);
            if (!__instance.p.isAI)
            {
                __instance.speed = __instance.p.boostSpeed;
                __instance.speedTarget = __instance.p.stats.grindSpeed;
            }
            __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);
            if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueFootGrindName5, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind5), true, false, 0f);
                }
                if (__instance.curTrick == 1)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueFootGrindName6, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind6), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueFootGrindName7, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind7), true, false, 0f);
                }
            }
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueSkateboardGrindName5, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind5), true, false, 0f);
                }
                if (__instance.curTrick == 1)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueSkateboardGrindName6, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind6), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueSkateboardGrindName7, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind7), true, false, 0f);
                }
            }
            if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueInlineGrindName5, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind5), true, false, 0f);
                }
                if (__instance.curTrick == 1)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueInlineGrindName6, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind6), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueInlineGrindName7, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind7), true, false, 0f);
                }
            }
            if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueBMXGrindName5, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind5), true, false, 0f);
                }
                if (__instance.curTrick == 1)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueBMXGrindName6, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind6), true, false, 0f);
                }
                if (__instance.curTrick == 2)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_BOOST, configValueBMXGrindName7, __instance.curTrick);
                    __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind7), true, false, 0f);
                }
            }
            return false;
        }
        [HarmonyPatch(typeof(GrindAbility), nameof(GrindAbility.StartGrindTrick))]
        [HarmonyPrefix]
        private static bool StartGrindTrickPRF(GrindAbility __instance, bool first = false, bool switchToEquippedMovestyle = false)
            {
                string configValueFootGrind1 = GriTAPatchTC.Instance.GetConfigValueGrind("footStartGrindTrickcfg");
                string configValueFootGrind2 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick0cfg");
                string configValueFootGrind3 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick1cfg");
                string configValueFootGrind4 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick2cfg");
                string configValueFootGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("footStartGrindTrick2cfg");

                string configValueFootGrindName1 = GriTAPatchTC.Instance.GetConfigValueGrind("footStartGrindTrickNamecfg");
                //string configValueFootGrindName2 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick0Namecfg");
                //string configValueFootGrindName3 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick1Namecfg");
                //string configValueFootGrindName4 = GriTAPatchTC.Instance.GetConfigValueGrind("footGrindTrick2Namecfg");
            string configValueFootGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("footStartGrindTrick2Namecfg");

            string configValueInlineGrind1 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineStartGrindTrickcfg");
            string configValueInlineGrind2 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick0cfg");
            string configValueInlineGrind3 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick1cfg");
            string configValueInlineGrind4 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick2cfg");
            string configValueInlineGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineStartGrindTrick2cfg");

            string configValueInlineGrindName1 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineStartGrindTrickNamecfg");
            //string configValueInlineGrindName2 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick0Namecfg");
            //string configValueInlineGrindName3 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick1Namecfg");
            //string configValueInlineGrindName4 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineGrindTrick2Namecfg");
            string configValueInlineGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("inlineStartGrindTrick2Namecfg");

            string configValueSkateboardGrind1 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardStartGrindTrickcfg");
            string configValueSkateboardGrind2 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick0cfg");
            string configValueSkateboardGrind3 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick1cfg");
            string configValueSkateboardGrind4 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick2cfg");
            string configValueSkateboardGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardStartGrindTrick2cfg");

            string configValueSkateboardGrindName1 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardStartGrindTrickNamecfg");
            //string configValueSkateboardGrindName2 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick0Namecfg");
            //string configValueSkateboardGrindName3 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick1Namecfg");
            //string configValueSkateboardGrindName4 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardGrindTrick2Namecfg");
            string configValueSkateboardGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("skateboardStartGrindTrick2Namecfg");

            string configValueBMXGrind1 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxStartGrindTrickcfg");
            string configValueBMXGrind2 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick0cfg");
            string configValueBMXGrind3 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick1cfg");
            string configValueBMXGrind4 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick2cfg");
            string configValueBMXGrind5 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxStartGrindTrick2cfg");

            string configValueBMXGrindName1 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxStartGrindTrickNamecfg");
            //string configValueBMXGrindName2 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick0Namecfg");
            //string configValueBMXGrindName3 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick1Namecfg");
            //string configValueBMXGrindName4 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxGrindTrick2Namecfg");
            string configValueBMXGrindName5 = GriTAPatchTC.Instance.GetConfigValueGrind("bmxStartGrindTrick2Namecfg");

            __instance.curTrickFirst = first;
                __instance.curTrickBoost = false;
                __instance.p.didAbilityTrick = false;
                if (switchToEquippedMovestyle)
                {
                    string trickName = configValueSkateboardGrindName1;
                    if (__instance.p.moveStyle == MoveStyle.INLINE)
                    {
                        trickName = configValueInlineGrindName1;
                    }
                    else if (__instance.p.moveStyle == MoveStyle.BMX)
                    {
                        trickName = configValueBMXGrindName1;
                    }
                else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    trickName = configValueFootGrindName1;
                }
                __instance.p.DoTrick(Player.TrickType.GRIND_SWITCH_MOVESTYLE, trickName, 0);
                    __instance.trickTimer = (__instance.curTrickDuration = __instance.trickStandardDuration);
                if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind1), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind1), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind1), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind1), false, false, -1f);
                }
                __instance.curTrick = 1;
                    return false;
                }
                __instance.curTrick = __instance.p.InputToTrickNumber();
                __instance.p.TempSetSpeedAnim(1f);
                if (__instance.p.CheckBoostTrick())
                {
                    __instance.DoBoostTrick();
                }
                else if (first)
                {
                    __instance.curTrick = 1;
                if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_START, configValueFootGrindName5, __instance.curTrick);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind5), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_START, configValueSkateboardGrindName5, __instance.curTrick);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind5), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_START, configValueInlineGrindName5, __instance.curTrick);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind5), false, false, -1f);
                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    __instance.p.DoTrick(Player.TrickType.GRIND_START, configValueBMXGrindName5, __instance.curTrick);
                    __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind5), false, false, -1f);
                }
            }
                else
                {
                    __instance.p.hitbox.SetActive(true);
                    __instance.trickTimer = (__instance.curTrickDuration = __instance.trickStandardDuration);
                    if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                    {
                        if (__instance.curTrick == 0 && configValueFootGrind2 != null)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind2), true, false, 0f);
                        }
                        else if (configValueFootGrind2 == null)
                        {
                            Debug.LogError("Config value for footGrindBoostTrick0cfg is null!");
                        }

                        if (__instance.curTrick == 1 && configValueFootGrind3 != null)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind3), true, false, 0f);
                        }
                        else if (configValueFootGrind3 == null)
                        {
                            Debug.LogError("Config value for footGrindBoostTrick1cfg is null!");
                        }

                        if (__instance.curTrick == 2 && configValueFootGrind4 != null)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueFootGrind4), true, false, 0f);
                        }
                        else if (configValueFootGrind4 == null)
                        {
                            Debug.LogError("Config value for footGrindBoostTrick2cfg is null!");
                        }
                    }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    if (__instance.curTrick == 0 && configValueInlineGrind2 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind2), true, false, 0f);
                    }
                    else if (configValueInlineGrind2 == null)
                    {
                        Debug.LogError("Config value for inlineGrindBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueInlineGrind3 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind3), true, false, 0f);
                    }
                    else if (configValueInlineGrind3 == null)
                    {
                        Debug.LogError("Config value for inlineGrindBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueInlineGrind4 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueInlineGrind4), true, false, 0f);
                    }
                    else if (configValueInlineGrind4 == null)
                    {
                        Debug.LogError("Config value for inlineGrindBoostTrick2cfg is null!");
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    if (__instance.curTrick == 0 && configValueSkateboardGrind2 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind2), true, false, 0f);
                    }
                    else if (configValueSkateboardGrind2 == null)
                    {
                        Debug.LogError("Config value for skateboardGrindBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueSkateboardGrind3 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind3), true, false, 0f);
                    }
                    else if (configValueSkateboardGrind3 == null)
                    {
                        Debug.LogError("Config value for skateboardGrindBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueSkateboardGrind4 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueSkateboardGrind4), true, false, 0f);
                    }
                    else if (configValueSkateboardGrind4 == null)
                    {
                        Debug.LogError("Config value for skateboardGrindBoostTrick2cfg is null!");
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    if (__instance.curTrick == 0 && configValueBMXGrind2 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind2), true, false, 0f);
                    }
                    else if (configValueBMXGrind2 == null)
                    {
                        Debug.LogError("Config value for bmxGrindBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueBMXGrind3 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind3), true, false, 0f);
                    }
                    else if (configValueBMXGrind3 == null)
                    {
                        Debug.LogError("Config value for bmxGrindBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueBMXGrind4 != null)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueBMXGrind4), true, false, 0f);
                    }
                    else if (configValueBMXGrind4 == null)
                    {
                        Debug.LogError("Config value for bmxGrindBoostTrick2cfg is null!");
                    }
                }
                else
                    {
                        __instance.p.PlayAnim(__instance.grindTrickHashes[__instance.curTrick], true, false, 0f);
                    }
                }
                __instance.trickBuffered = (__instance.reTrickFail = false);
                return false;
            }
        }
    }