using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Reptile;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("ConfigTrixAirTricks", "New Trix Air", "1.4.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class ATAPatchTC : BaseUnityPlugin
    {
        public static ATAPatchTC Instance { get; private set; }

        public static Dictionary<string, bool> IdleOverrides = new Dictionary<string, bool>();

        private void Awake()
        {
            IdleOverrides["skateboardAirTrick0cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Trick 0 Fall Override", false, "Override fall for Button 1 trick (FALL OVERRIDES REQUIRE GAME RESTART TO TAKE EFFECT)").Value;
            IdleOverrides["skateboardAirTrick1cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Trick 1 Fall Override", false, "Override fall for Button 2 trick").Value;
            IdleOverrides["skateboardAirTrick2cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Trick 2 Fall Override", false, "Override fall for Button 3 trick").Value;
            IdleOverrides["skateboardAirBoostTrick0cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Boost Trick 0 Fall Override", false, "Override fall for Button 1 boost trick").Value;
            IdleOverrides["skateboardAirBoostTrick1cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Boost Trick 1 Fall Override", false, "Override fall for Button 2 boost trick").Value;
            IdleOverrides["skateboardAirBoostTrick2cfg"] = Config.Bind("Skateboard Air Tricks", "Skateboard Boost Trick 2 Fall Override", false, "Override fall for Button 3 boost trick").Value;

            IdleOverrides["inlineAirTrick0cfg"] = Config.Bind("Inline Air Tricks", "Inline Trick 0 Fall Override", false, "Override fall for Button 1 trick (FALL OVERRIDES REQUIRE GAME RESTART TO TAKE EFFECT)").Value;
            IdleOverrides["inlineAirTrick1cfg"] = Config.Bind("Inline Air Tricks", "Inline Trick 1 Fall Override", false, "Override fall for Button 2 trick").Value;
            IdleOverrides["inlineAirTrick2cfg"] = Config.Bind("Inline Air Tricks", "Inline Trick 2 Fall Override", false, "Override fall for Button 3 trick").Value;
            IdleOverrides["inlineAirBoostTrick0cfg"] = Config.Bind("Inline Air Tricks", "Inline Boost Trick 0 Fall Override", false, "Override fall for Button 1 boost trick").Value;
            IdleOverrides["inlineAirBoostTrick1cfg"] = Config.Bind("Inline Air Tricks", "Inline Boost Trick 1 Fall Override", false, "Override fall for Button 2 boost trick").Value;
            IdleOverrides["inlineAirBoostTrick2cfg"] = Config.Bind("Inline Air Tricks", "Inline Boost Trick 2 Fall Override", false, "Override fall for Button 3 boost trick").Value;

            IdleOverrides["bmxAirTrick0cfg"] = Config.Bind("BMX Air Tricks", "Bmx Trick 0 Fall Override", false, "Override fall for Button 1 trick (FALL OVERRIDES REQUIRE GAME RESTART TO TAKE EFFECT)").Value;
            IdleOverrides["bmxAirTrick1cfg"] = Config.Bind("BMX Air Tricks", "Bmx Trick 1 Fall Override", false, "Override fall for Button 2 trick").Value;
            IdleOverrides["bmxAirTrick2cfg"] = Config.Bind("BMX Air Tricks", "Bmx Trick 2 Fall Override", false, "Override fall for Button 3 trick").Value;
            IdleOverrides["bmxAirBoostTrick0cfg"] = Config.Bind("BMX Air Tricks", "Bmx Boost Trick 0 Fall Override", false, "Override fall for Button 1 boost trick").Value;
            IdleOverrides["bmxAirBoostTrick1cfg"] = Config.Bind("BMX Air Tricks", "Bmx Boost Trick 1 Fall Override", false, "Override fall for Button 2 boost trick").Value;
            IdleOverrides["bmxAirBoostTrick2cfg"] = Config.Bind("BMX Air Tricks", "Bmx Boost Trick 2 Fall Override", false, "Override fall for Button 3 boost trick").Value;

            IdleOverrides["footAirTrick0cfg"] = Config.Bind("On-foot Air Tricks", "Foot Trick 0 Fall Override", false, "Override fall for Button 1 trick (FALL OVERRIDES REQUIRE GAME RESTART TO TAKE EFFECT)").Value;
            IdleOverrides["footAirTrick1cfg"] = Config.Bind("On-foot Air Tricks", "Foot Trick 1 Fall Override", false, "Override fall for Button 2 trick").Value;
            IdleOverrides["footAirTrick2cfg"] = Config.Bind("On-foot Air Tricks", "Foot Trick 2 Fall Override", false, "Override fall for Button 3 trick").Value;
            IdleOverrides["footAirBoostTrick0cfg"] = Config.Bind("On-foot Air Tricks", "Foot Boost Trick 0 Fall Override", false, "Override fall for Button 1 boost trick").Value;
            IdleOverrides["footAirBoostTrick1cfg"] = Config.Bind("On-foot Air Tricks", "Foot Boost Trick 1 Fall Override", false, "Override fall for Button 2 boost trick").Value;
            IdleOverrides["footAirBoostTrick2cfg"] = Config.Bind("On-foot Air Tricks", "Foot Boost Trick 2 Fall Override", false, "Override fall for Button 3 boost trick").Value;

            //Left
            IdleOverrides["footAirTrickLeft0cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot TrickLeft 0 Fall Override", false, "Override fall for Button 1 TrickLeft").Value;
            IdleOverrides["footAirTrickLeft1cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot TrickLeft 1 Fall Override", false, "Override fall for Button 2 TrickLeft").Value;
            IdleOverrides["footAirTrickLeft2cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot TrickLeft 2 Fall Override", false, "Override fall for Button 3 TrickLeft").Value;
            IdleOverrides["footAirBoostTrickLeft0cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot Boost TrickLeft 0 Fall Override", false, "Override fall for Button 1 boost TrickLeft").Value;
            IdleOverrides["footAirBoostTrickLeft1cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot Boost TrickLeft 1 Fall Override", false, "Override fall for Button 2 boost TrickLeft").Value;
            IdleOverrides["footAirBoostTrickLeft2cfg"] = Config.Bind("On-foot Left Air Tricks", "Foot Boost TrickLeft 2 Fall Override", false, "Override fall for Button 3 boost TrickLeft").Value;

            //Right
            IdleOverrides["footAirTrickRight0cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot TrickRight 0 Fall Override", false, "Override fall for Button 1 TrickRight").Value;
            IdleOverrides["footAirTrickRight1cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot TrickRight 1 Fall Override", false, "Override fall for Button 2 TrickRight").Value;
            IdleOverrides["footAirTrickRight2cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot TrickRight 2 Fall Override", false, "Override fall for Button 3 TrickRight").Value;
            IdleOverrides["footAirBoostTrickRight0cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot Boost TrickRight 0 Fall Override", false, "Override fall for Button 1 boost TrickRight").Value;
            IdleOverrides["footAirBoostTrickRight1cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot Boost TrickRight 1 Fall Override", false, "Override fall for Button 2 boost TrickRight").Value;
            IdleOverrides["footAirBoostTrickRight2cfg"] = Config.Bind("On-foot Right Air Tricks", "Foot Boost TrickRight 2 Fall Override", false, "Override fall for Button 3 boost TrickRight").Value;

            //Up
            IdleOverrides["footAirTrickUp0cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot TrickUp 0 Fall Override", false, "Override fall for Button 1 TrickUp").Value;
            IdleOverrides["footAirTrickUp1cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot TrickUp 1 Fall Override", false, "Override fall for Button 2 TrickUp").Value;
            IdleOverrides["footAirTrickUp2cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot TrickUp 2 Fall Override", false, "Override fall for Button 3 TrickUp").Value;
            IdleOverrides["footAirBoostTrickUp0cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot Boost TrickUp 0 Fall Override", false, "Override fall for Button 1 boost TrickUp").Value;
            IdleOverrides["footAirBoostTrickUp1cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot Boost TrickUp 1 Fall Override", false, "Override fall for Button 2 boost TrickUp").Value;
            IdleOverrides["footAirBoostTrickUp2cfg"] = Config.Bind("On-foot Up Air Tricks", "Foot Boost TrickUp 2 Fall Override", false, "Override fall for Button 3 boost TrickUp").Value;

            //Down
            IdleOverrides["footAirTrickDown0cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot TrickDown 0 Fall Override", false, "Override fall for Button 1 TrickDown").Value;
            IdleOverrides["footAirTrickDown1cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot TrickDown 1 Fall Override", false, "Override fall for Button 2 TrickDown").Value;
            IdleOverrides["footAirTrickDown2cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot TrickDown 2 Fall Override", false, "Override fall for Button 3 TrickDown").Value;
            IdleOverrides["footAirBoostTrickDown0cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot Boost TrickDown 0 Fall Override", false, "Override fall for Button 1 boost TrickDown").Value;
            IdleOverrides["footAirBoostTrickDown1cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot Boost TrickDown 1 Fall Override", false, "Override fall for Button 2 boost TrickDown").Value;
            IdleOverrides["footAirBoostTrickDown2cfg"] = Config.Bind("On-foot Down Air Tricks", "Foot Boost TrickDown 2 Fall Override", false, "Override fall for Button 3 boost TrickDown").Value;
        


        ATAPatchTC.enableTonyCfg = base.Config.Bind<bool>("General", "enableTonyCfg", false, "Enable Beta Skateboard Directional Tricks");
            ATAPatchTC.Instance = this;
            this.configEntriesAir = new Dictionary<string, ConfigEntry<string>>
            {
                {
                    "skateboardAirTrick0cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 0", "airTrick0", "Button 1 trick")
                },
                {
                    "skateboardAirTrick0Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 0 Name", "Backside 360 Varial", "Button 1 trick name")
                },
                {
                    "skateboardAirTrick1cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 1", "airTrick1", "Button 2 trick")
                },
                {
                    "skateboardAirTrick1Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 1 Name", "Backflip Indy", "Button 2 trick name")
                },
                {
                    "skateboardAirTrick2cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 2", "jumpTrick1", "Button 3 trick (vanilla is \"airTrick2\")")
                },
                {
                    "skateboardAirTrick2Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Trick 2 Name", "McTwist", "Button 3 trick name (vanilla is \"Method Grab\")")
                },
                {
                    "skateboardAirBoostTrick0cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 0", "airBoostTrick0", "Button 1 boost trick")
                },
                {
                    "skateboardAirBoostTrick0Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 0 Name", "1080", "Button 1 boost trick name")
                },
                {
                    "skateboardAirBoostTrick1cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 1", "airBoostTrick1", "Button 2 boost trick")
                },
                {
                    "skateboardAirBoostTrick1Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 1 Name", "1080", "Button 2 boost trick name")
                },
                {
                    "skateboardAirBoostTrick2cfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 2", "airBoostTrick2", "Button 3 boost trick")
                },
                {
                    "skateboardAirBoostTrick2Namecfg",
                    base.Config.Bind<string>("Skateboard Air Tricks", "Skateboard Boost Trick 2 Name", "1080", "Button 3 boost trick name")
                },
                {
                    "inlineAirTrick0cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 0", "airTrick0", "Button 1 trick")
                },
                {
                    "inlineAirTrick0Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 0 Name", "Cork 720", "Button 1 trick name")
                },
                {
                    "inlineAirTrick1cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 1", "airTrick1", "Button 2 trick")
                },
                {
                    "inlineAirTrick1Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 1 Name", "Method Grab", "Button 2 trick name")
                },
                {
                    "inlineAirTrick2cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 2", "airTrick2", "Button 3 trick")
                },
                {
                    "inlineAirTrick2Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Trick 2 Name", "Abstract 360", "Button 3 trick name")
                },
                {
                    "inlineAirBoostTrick0cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 0", "airBoostTrick0", "Button 1 boost trick")
                },
                {
                    "inlineAirBoostTrick0Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 0 Name", "1080 California Roll", "Button 1 boost trick name")
                },
                {
                    "inlineAirBoostTrick1cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 1", "airBoostTrick1", "Button 2 boost trick")
                },
                {
                    "inlineAirBoostTrick1Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 1 Name", "1080 California Roll", "Button 2 boost trick name")
                },
                {
                    "inlineAirBoostTrick2cfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 2", "airBoostTrick2", "Button 3 boost trick")
                },
                {
                    "inlineAirBoostTrick2Namecfg",
                    base.Config.Bind<string>("Inline Air Tricks", "Inline Boost Trick 2 Name", "1080 California Roll", "Button 3 boost trick name")
                },
                {
                    "bmxAirTrick0cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 0", "airTrick0", "Button 1 trick")
                },
                {
                    "bmxAirTrick0Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 0 Name", "Tailwhip 360", "Button 1 trick name")
                },
                {
                    "bmxAirTrick1cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 1", "airTrick1", "Button 2 trick")
                },
                {
                    "bmxAirTrick1Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 1 Name", "No Hand Backflip", "Button 2 trick name")
                },
                {
                    "bmxAirTrick2cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 2", "airTrick2", "Button 3 trick")
                },
                {
                    "bmxAirTrick2Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Trick 2 Name", "Superman Seat Grab Indian", "Button 3 trick name")
                },
                {
                    "bmxAirBoostTrick0cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 0", "airBoostTrick0", "Button 1 boost trick")
                },
                {
                    "bmxAirBoostTrick0Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 0 Name", "720 Double Backflip", "Button 1 boost trick name")
                },
                {
                    "bmxAirBoostTrick1cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 1", "airBoostTrick1", "Button 2 boost trick")
                },
                {
                    "bmxAirBoostTrick1Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 1 Name", "720 Double Backflip", "Button 2 boost trick name")
                },
                {
                    "bmxAirBoostTrick2cfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 2", "airBoostTrick2", "Button 3 boost trick")
                },
                {
                    "bmxAirBoostTrick2Namecfg",
                    base.Config.Bind<string>("BMX Air Tricks", "Bmx Boost Trick 2 Name", "720 Double Backflip", "Button 3 boost trick name")
                },
                {
                    "footAirTrick0cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 0", "airTrick0", "Button 1 trick")
                },
                {
                    "footAirTrick0Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 0 Name", "Bullet Spin", "Button 1 trick name")
                },
                {
                    "footAirTrick1cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 1", "airTrick1", "Button 2 trick")
                },
                {
                    "footAirTrick1Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 1 Name", "Backflip Grab", "Button 2 trick name")
                },
                {
                    "footAirTrick2cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 2", "airTrick2", "Button 3 trick")
                },
                {
                    "footAirTrick2Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Trick 2 Name", "Cheat 720", "Button 3 trick name")
                },
                {
                    "footAirBoostTrick0cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 0", "airBoostTrick0", "Button 1 boost trick")
                },
                {
                    "footAirBoostTrick0Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 0 Name", "Shuriken", "Button 1 boost trick name")
                },
                {
                    "footAirBoostTrick1cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 1", "airBoostTrick1", "Button 2 boost trick")
                },
                {
                    "footAirBoostTrick1Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 1 Name", "Shuriken", "Button 2 boost trick name")
                },
                {
                    "footAirBoostTrick2cfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 2", "airBoostTrick2", "Button 3 boost trick")
                },
                {
                    "footAirBoostTrick2Namecfg",
                    base.Config.Bind<string>("On-foot Air Tricks", "Foot Boost Trick 2 Name", "Shuriken", "Button 3 boost trick name")
                },

                //Left
                {
                    "footAirTrickLeft0cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 0", "", "Button 1 TrickLeft")
                },
                // {
                //     "footAirTrickLeft0Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 0 Name", "", "Button 1 TrickLeft name")
                // },
                {
                    "footAirTrickLeft1cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 1", "", "Button 2 TrickLeft")
                },
                // {
                //     "footAirTrickLeft1Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 1 Name", "", "Button 2 TrickLeft name")
                // },
                {
                    "footAirTrickLeft2cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 2", "", "Button 3 TrickLeft")
                },
                // {
                //     "footAirTrickLeft2Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot TrickLeft 2 Name", "", "Button 3 TrickLeft name")
                // },
                {
                    "footAirBoostTrickLeft0cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 0", "", "Button 1 boost TrickLeft")
                },
                // {
                //     "footAirBoostTrickLeft0Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 0 Name", "", "Button 1 boost TrickLeft name")
                // },
                {
                    "footAirBoostTrickLeft1cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 1", "", "Button 2 boost TrickLeft")
                },
                // {
                //     "footAirBoostTrickLeft1Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 1 Name", "", "Button 2 boost TrickLeft name")
                // },
                {
                    "footAirBoostTrickLeft2cfg",
                    base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 2", "", "Button 3 boost TrickLeft")
                },
                // {
                //     "footAirBoostTrickLeft2Namecfg",
                //     base.Config.Bind<string>("On-foot Left Air Tricks", "Foot Boost TrickLeft 2 Name", "", "Button 3 boost TrickLeft name")
                // },
                
                //Right
                {
                    "footAirTrickRight0cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 0", "", "Button 1 TrickRight")
                },
                // {
                //     "footAirTrickRight0Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 0 Name", "", "Button 1 TrickRight name")
                // },
                {
                    "footAirTrickRight1cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 1", "", "Button 2 TrickRight")
                },
                // {
                //     "footAirTrickRight1Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 1 Name", "", "Button 2 TrickRight name")
                // },
                {
                    "footAirTrickRight2cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 2", "", "Button 3 TrickRight")
                },
                // {
                //     "footAirTrickRight2Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot TrickRight 2 Name", "", "Button 3 TrickRight name")
                // },
                {
                    "footAirBoostTrickRight0cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 0", "", "Button 1 boost TrickRight")
                },
                // {
                //     "footAirBoostTrickRight0Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 0 Name", "", "Button 1 boost TrickRight name")
                // },
                {
                    "footAirBoostTrickRight1cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 1", "", "Button 2 boost TrickRight")
                },
                // {
                //     "footAirBoostTrickRight1Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 1 Name", "", "Button 2 boost TrickRight name")
                // },
                {
                    "footAirBoostTrickRight2cfg",
                    base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 2", "", "Button 3 boost TrickRight")
                },
                // {
                //     "footAirBoostTrickRight2Namecfg",
                //     base.Config.Bind<string>("On-foot Right Air Tricks", "Foot Boost TrickRight 2 Name", "", "Button 3 boost TrickRight name")
                // },
                
                //Up
                {
                    "footAirTrickUp0cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 0", "", "Button 1 TrickUp")
                },
                // {
                //     "footAirTrickUp0Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 0 Name", "", "Button 1 TrickUp name")
                // },
                {
                    "footAirTrickUp1cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 1", "", "Button 2 TrickUp")
                },
                // {
                //     "footAirTrickUp1Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 1 Name", "", "Button 2 TrickUp name")
                // },
                {
                    "footAirTrickUp2cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 2", "", "Button 3 TrickUp")
                },
                // {
                //     "footAirTrickUp2Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot TrickUp 2 Name", "", "Button 3 TrickUp name")
                // },
                {
                    "footAirBoostTrickUp0cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 0", "", "Button 1 boost TrickUp")
                },
                // {
                //     "footAirBoostTrickUp0Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 0 Name", "", "Button 1 boost TrickUp name")
                // },
                {
                    "footAirBoostTrickUp1cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 1", "", "Button 2 boost TrickUp")
                },
                // {
                //     "footAirBoostTrickUp1Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 1 Name", "", "Button 2 boost TrickUp name")
                // },
                {
                    "footAirBoostTrickUp2cfg",
                    base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 2", "", "Button 3 boost TrickUp")
                },
                // {
                //     "footAirBoostTrickUp2Namecfg",
                //     base.Config.Bind<string>("On-foot Up Air Tricks", "Foot Boost TrickUp 2 Name", "", "Button 3 boost TrickUp name")
                // },
                
                //Down
                {
                    "footAirTrickDown0cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 0", "", "Button 1 TrickDown")
                },
                // {
                //     "footAirTrickDown0Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 0 Name", "", "Button 1 TrickDown name")
                // },
                {
                    "footAirTrickDown1cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 1", "", "Button 2 TrickDown")
                },
                // {
                //     "footAirTrickDown1Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 1 Name", "", "Button 2 TrickDown name")
                // },
                {
                    "footAirTrickDown2cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 2", "", "Button 3 TrickDown")
                },
                // {
                //     "footAirTrickDown2Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot TrickDown 2 Name", "", "Button 3 TrickDown name")
                // },
                {
                    "footAirBoostTrickDown0cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 0", "", "Button 1 boost TrickDown")
                },
                // {
                //     "footAirBoostTrickDown0Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 0 Name", "", "Button 1 boost TrickDown name")
                // },
                {
                    "footAirBoostTrickDown1cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 1", "", "Button 2 boost TrickDown")
                },
                // {
                //     "footAirBoostTrickDown1Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 1 Name", "", "Button 2 boost TrickDown name")
                // },
                {
                    "footAirBoostTrickDown2cfg",
                    base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 2", "", "Button 3 boost TrickDown")
                },
                // {
                //     "footAirBoostTrickDown2Namecfg",
                //     base.Config.Bind<string>("On-foot Down Air Tricks", "Foot Boost TrickDown 2 Name", "", "Button 3 boost TrickDown name")
                // }



            };
        }

        public string GetConfigValueAir(string key)
        {
            ConfigEntry<string> configEntry;
            bool flag = this.configEntriesAir.TryGetValue(key, out configEntry);
            string result;
            if (flag)
            {
                result = configEntry.Value;
            }
            else
            {
                base.Logger.LogWarning("Configuration key '" + key + "' not found.");
                result = null;
            }
            return result;
        }

        public static bool GetTonyCfg()
        {
            return ATAPatchTC.enableTonyCfg.Value;
        }

        [HarmonyPatch(typeof(AirTrickAbility), "Init")]
        [HarmonyPrefix]
        private static bool Init_Prefix(AirTrickAbility __instance)
        {
            bool flag = ATAPatchTC.Instance == null;
            bool result;
            if (flag)
            {
                result = true;
            }
            else
            {
                string configValueAir = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick0Namecfg");
                string configValueAir2 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick1Namecfg");
                string configValueAir3 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick2Namecfg");
                string configValueAir4 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick0Namecfg");
                string configValueAir5 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick1Namecfg");
                string configValueAir6 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick2Namecfg");
                string configValueAir7 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick0Namecfg");
                string configValueAir8 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick1Namecfg");
                string configValueAir9 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick2Namecfg");
                string configValueAir10 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick0Namecfg");
                string configValueAir11 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick1Namecfg");
                string configValueAir12 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick2Namecfg");
                string configValueAir13 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick0Namecfg");
                string configValueAir14 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick1Namecfg");
                string configValueAir15 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick2Namecfg");
                string configValueAir16 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick0Namecfg");
                string configValueAir17 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick1Namecfg");
                string configValueAir18 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick2Namecfg");
                string configValueAir19 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick0Namecfg");
                string configValueAir20 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick1Namecfg");
                string configValueAir21 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick2Namecfg");
                string configValueAir22 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick0Namecfg");
                string configValueAir23 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick1Namecfg");
                string configValueAir24 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick2Namecfg");

                __instance.skateboardTrickNames = new string[]
                {
                    configValueAir,
                    configValueAir2,
                    configValueAir3,
                    configValueAir4,
                    configValueAir5,
                    configValueAir6
                };
                __instance.inlineTrickNames = new string[]
                {
                    configValueAir7,
                    configValueAir8,
                    configValueAir9,
                    configValueAir10,
                    configValueAir11,
                    configValueAir12
                };
                __instance.bmxTrickNames = new string[]
                {
                    configValueAir13,
                    configValueAir14,
                    configValueAir15,
                    configValueAir16,
                    configValueAir17,
                    configValueAir18
                };
                __instance.trickingTrickNames = new string[]
                {
                    configValueAir19,
                    configValueAir20,
                    configValueAir21,
                    configValueAir22,
                    configValueAir23,
                    configValueAir24
                };
                result = true;
            }
            return result;
        }

        [HarmonyPatch(typeof(AirTrickAbility), "OnStartAbility")]
        [HarmonyPrefix]
        private static bool OnStartAbilityPrefix(AirTrickAbility __instance)
        {
            

            if (ATAPatchTC.Instance == null)
            {
                return true;
            }

            string configValueAir = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick0cfg");
            string configValueAir2 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick1cfg");
            string configValueAir3 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirTrick2cfg");
            string configValueAir4 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick0cfg");
            string configValueAir5 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick1cfg");
            string configValueAir6 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirTrick2cfg");
            string configValueAir7 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick0cfg");
            string configValueAir8 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick1cfg");
            string configValueAir9 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirTrick2cfg");
            string configValueAir10 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick0cfg");
            string configValueAir11 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick1cfg");
            string configValueAir12 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrick2cfg");

            string footAirTrickLeft0 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickLeft0cfg");
            string footAirTrickLeft1 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickLeft1cfg");
            string footAirTrickLeft2 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickLeft2cfg");

            string footAirTrickRight0 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickRight0cfg");
            string footAirTrickRight1 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickRight1cfg");
            string footAirTrickRight2 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickRight2cfg");

            string footAirTrickUp0 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickUp0cfg");
            string footAirTrickUp1 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickUp1cfg");
            string footAirTrickUp2 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickUp2cfg");

            string footAirTrickDown0 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickDown0cfg");
            string footAirTrickDown1 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickDown1cfg");
            string footAirTrickDown2 = ATAPatchTC.Instance.GetConfigValueAir("footAirTrickDown2cfg");

            __instance.hitEnemy = false;
            __instance.p.SetDustEmission(0);
            __instance.curTrick = __instance.p.InputToTrickNumber();
            __instance.bufferSwitchStyle = false;
            __instance.targetSpeed = -1f;
            __instance.rotateSpeed = -1f;
            __instance.decc = -1f;
            __instance.trickType = AirTrickAbility.TrickType.NORMAL_TRICK;
            __instance.duration = __instance.trickingTrickDuration;

            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD || __instance.p.moveStyle == MoveStyle.SPECIAL_SKATEBOARD)
            {
                __instance.duration = __instance.skateboardTrickDuration;
            }
            else if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                __instance.duration = __instance.bmxTrickDuration;
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                __instance.duration = __instance.inlineTrickDuration;
            }

            if (__instance.p.CheckBoostTrick())
            {
                __instance.SetupBoostTrick();
            }
            else
            {
                __instance.p.PlayAnim(__instance.airTrickHashes[__instance.curTrick], true, false, 0f);

                // ON FOOT DIRECTIONAL UPDATE
                if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    if (__instance.curTrick == 0)
                    {
                        if (__instance.p.moveAxisX <= -0.75f && footAirTrickLeft0 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickLeft0), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickLeft0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisX >= 0.75f && footAirTrickRight0 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickRight0), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickRight0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY >= 0.75f && footAirTrickUp0 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickUp0), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickUp0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY <= -0.75f && footAirTrickDown0 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickDown0), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickDown0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir10), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrick0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    if (__instance.curTrick == 1)
                    {
                        if (__instance.p.moveAxisX <= -0.75f && footAirTrickLeft1 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickLeft1), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickLeft1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisX >= 0.75f && footAirTrickRight1 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickRight1), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickRight1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY >= 0.75f && footAirTrickUp1 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickUp1), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickUp1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY <= -0.75f && footAirTrickDown1 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickDown1), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickDown1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir11), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrick1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    if (__instance.curTrick == 2)
                    {
                        if (__instance.p.moveAxisX <= -0.75f && footAirTrickLeft2 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickLeft2), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickLeft2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisX >= 0.75f && footAirTrickRight2 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickRight2), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickRight2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY >= 0.75f && footAirTrickUp2 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickUp2), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickUp2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else if (__instance.p.moveAxisY <= -0.75f && footAirTrickDown2 != "")
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrickDown2), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrickDown2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir12), true, false, 0f);
                            if (ATAPatchTC.IdleOverrides["footAirTrick2cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }

                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    if (__instance.curTrick == 0)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir7), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir8), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.curTrick == 2)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir9), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["bmxAirTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    if (__instance.curTrick == 0)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir4), true, false, -1f);
                        if (ATAPatchTC.IdleOverrides["inlineAirTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.curTrick == 1)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir5), true, false, -1f);
                        if (ATAPatchTC.IdleOverrides["inlineAirTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.curTrick == 2)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir6), true, false, -1f);
                        if (ATAPatchTC.IdleOverrides["inlineAirTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    bool enableTonyCfg = ATAPatchTC.enableTonyCfg.Value;
                    if (__instance.curTrick == 0)
                    {
                        float moveAxisX = __instance.p.moveAxisX;
                        float moveAxisY = __instance.p.moveAxisY;
                        if (enableTonyCfg)
                        {
                            if (moveAxisX <= -0.25f)
                            {
                                if (moveAxisY <= -0.25f || moveAxisY >= 0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir), true, false, -1f);
                                    if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                    { VertAbilityPatches.overridingIdle = true; }
                                    else
                                    { VertAbilityPatches.overridingIdle = false; }
                                }
                                else
                                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick0"), true, false, -1f);
                                VertAbilityPatches.overridingIdle = false;
                            }
                            else if (moveAxisX >= 0.25f)
                            {
                                if (moveAxisY <= -0.25f || moveAxisY >= 0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir), true, false, -1f);
                                    if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                    { VertAbilityPatches.overridingIdle = true; }
                                    else
                                    { VertAbilityPatches.overridingIdle = false; }
                                }
                                else
                                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick2"), true, false, -1f);
                                VertAbilityPatches.overridingIdle = false;
                            }
                            else if (moveAxisY <= -0.25f)
                            {
                                __instance.p.PlayAnim(Animator.StringToHash("grindTrick0"), true, false, -1f);
                                VertAbilityPatches.overridingIdle = false;
                            }
                            else if (moveAxisY >= 0.25f)
                            {
                                __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, -1f);
                                VertAbilityPatches.overridingIdle = false;
                            }
                            else
                            {
                                __instance.p.PlayAnim(Animator.StringToHash(configValueAir), true, false, -1f);
                                if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                                { VertAbilityPatches.overridingIdle = true; }
                                else
                                { VertAbilityPatches.overridingIdle = false; }
                            }
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir), true, false, -1f);
                            if (ATAPatchTC.IdleOverrides["skateboardAirTrick0cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    else if (__instance.curTrick == 1)
                    {
                        if (enableTonyCfg && __instance.p.slideButtonHeld)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash("groundBoostTrick0"), false, false, -1f);
                            VertAbilityPatches.overridingIdle = false;
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir2), false, false, -1f);
                            if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                    else if (__instance.curTrick == 2)
                    {
                        if (enableTonyCfg)
                        {
                            if (__instance.p.moveAxisX >= 0.25f)
                            {
                                if (__instance.p.moveAxisY <= -0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash("airBoostTrick2"), false, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                                else if (__instance.p.moveAxisY >= 0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir3), false, false, -1f);
                                    if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                    { VertAbilityPatches.overridingIdle = true; }
                                    else
                                    { VertAbilityPatches.overridingIdle = false; }
                                }
                                else
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash("airTrick1"), false, false, -1f);
                                    VertAbilityPatches.overridingIdle = false;
                                }
                            }
                            else
                            {
                                __instance.p.PlayAnim(Animator.StringToHash(configValueAir3), false, false, -1f);
                                if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                                { VertAbilityPatches.overridingIdle = true; }
                                else
                                { VertAbilityPatches.overridingIdle = false; }
                            }
                        }
                        else
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(configValueAir3), false, false, -1f);
                            if (ATAPatchTC.IdleOverrides["skateboardAirTrick1cfg"])
                            { VertAbilityPatches.overridingIdle = true; }
                            else
                            { VertAbilityPatches.overridingIdle = false; }
                        }
                    }
                }

                __instance.p.hitboxLeftLeg.SetActive(false);
                __instance.p.hitboxRightLeg.SetActive(false);
                __instance.p.hitboxUpperBody.SetActive(false);
            }

            return false;
        }

        [HarmonyPatch(typeof(AirTrickAbility), "SetupBoostTrick")]
        [HarmonyPrefix]
        private static bool SetupBoostTrick_Prefix(AirTrickAbility __instance)
        {
            string configValueAir = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick0cfg");
            string configValueAir2 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick1cfg");
            string configValueAir3 = ATAPatchTC.Instance.GetConfigValueAir("skateboardAirBoostTrick2cfg");
            string configValueAir4 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick0cfg");
            string configValueAir5 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick1cfg");
            string configValueAir6 = ATAPatchTC.Instance.GetConfigValueAir("inlineAirBoostTrick2cfg");
            string configValueAir7 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick0cfg");
            string configValueAir8 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick1cfg");
            string configValueAir9 = ATAPatchTC.Instance.GetConfigValueAir("bmxAirBoostTrick2cfg");
            string configValueAir10 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick0cfg");
            string configValueAir11 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick1cfg");
            string configValueAir12 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrick2cfg");

            string footAirBoostTrickLeft0 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickLeft0cfg");
            string footAirBoostTrickLeft1 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickLeft1cfg");
            string footAirBoostTrickLeft2 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickLeft2cfg");

            string footAirBoostTrickRight0 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickRight0cfg");
            string footAirBoostTrickRight1 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickRight1cfg");
            string footAirBoostTrickRight2 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickRight2cfg");

            string footAirBoostTrickUp0 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickUp0cfg");
            string footAirBoostTrickUp1 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickUp1cfg");
            string footAirBoostTrickUp2 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickUp2cfg");

            string footAirBoostTrickDown0 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickDown0cfg");
            string footAirBoostTrickDown1 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickDown1cfg");
            string footAirBoostTrickDown2 = ATAPatchTC.Instance.GetConfigValueAir("footAirBoostTrickDown2cfg");

            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick0cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir2), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick1cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 2)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir3), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["skateboardAirBoostTrick2cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir4), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick0cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir5), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick1cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 2)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir6), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["inlineAirBoostTrick2cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                if (__instance.curTrick == 0)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir7), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick0cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 1)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir8), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick1cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
                else if (__instance.curTrick == 2)
                {
                    __instance.p.PlayAnim(Animator.StringToHash(configValueAir9), true, false, 0f);
                    if (ATAPatchTC.IdleOverrides["bmxAirBoostTrick2cfg"])
                    { VertAbilityPatches.overridingIdle = true; }
                    else
                    { VertAbilityPatches.overridingIdle = false; }
                }
            }
            // ON FOOT DIRECTIONAL UPDATE
            else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
            {
                if (__instance.curTrick == 0)
                {
                    if (__instance.p.moveAxisX <= -0.75f && footAirBoostTrickLeft0 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickLeft0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickLeft0cfg"])
                        {
                            //Console.WriteLine("trick overridingIdle = true");
                            VertAbilityPatches.overridingIdle = true; 
                        }
                        else
                        {
                            //Console.WriteLine("trick overridingIdle = false");
                            VertAbilityPatches.overridingIdle = false; 
                        }
                    }
                    else if (__instance.p.moveAxisX >= 0.75f && footAirBoostTrickRight0 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickRight0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickRight0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY >= 0.75f && footAirBoostTrickUp0 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickUp0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickUp0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY <= -0.75f && footAirBoostTrickDown0 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickDown0), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickDown0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir10), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrick0cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                if (__instance.curTrick == 1)
                {
                    if (__instance.p.moveAxisX <= -0.75f && footAirBoostTrickLeft1 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickLeft1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickLeft1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisX >= 0.75f && footAirBoostTrickRight1 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickRight1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickRight1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY >= 0.75f && footAirBoostTrickUp1 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickUp1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickUp1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY <= -0.75f && footAirBoostTrickDown1 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickDown1), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickDown1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir11), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrick1cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }
                if (__instance.curTrick == 2)
                {
                    if (__instance.p.moveAxisX <= -0.75f && footAirBoostTrickLeft2 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickLeft2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickLeft2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisX >= 0.75f && footAirBoostTrickRight2 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickRight2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickRight2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY >= 0.75f && footAirBoostTrickUp2 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickUp2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickUp2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else if (__instance.p.moveAxisY <= -0.75f && footAirBoostTrickDown2 != "")
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrickDown2), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrickDown2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                    else
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(configValueAir12), true, false, 0f);
                        if (ATAPatchTC.IdleOverrides["footAirBoostTrick2cfg"])
                        { VertAbilityPatches.overridingIdle = true; }
                        else
                        { VertAbilityPatches.overridingIdle = false; }
                    }
                }

            }

            __instance.p.PlayVoice(AudioClipID.VoiceBoostTrick, VoicePriority.BOOST_TRICK, true);
            __instance.p.ringParticles.Emit(1);
            __instance.trickType = AirTrickAbility.TrickType.BOOST_TRICK;
            __instance.duration *= 1.5f;

            if (!__instance.p.isAI)
                __instance.p.SetForwardSpeed(__instance.p.boostSpeed);

            __instance.p.AddBoostCharge(-__instance.p.boostTrickCost);

            return false;
        }

        public static ConfigEntry<bool> enableTonyCfg;

private Dictionary<string, ConfigEntry<string>> configEntriesAir;
    }
}
