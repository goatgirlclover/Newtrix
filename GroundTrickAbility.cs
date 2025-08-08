using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Reptile;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("ConfigTrixGroundTricks", "New Trix Ground", "1.4.1")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class GTAPatchTC : BaseUnityPlugin
    {
        public static GTAPatchTC Instance { get; private set; }

        private Dictionary<string, ConfigEntry<string>> configEntriesGround;

        public static Dictionary<string, bool> IdleOverrides = new Dictionary<string, bool>();

        public static void CheckAnimOverride(bool overrideAnim)
        {
            if (overrideAnim)
            {
                VertAbilityPatches.UseFootController();
            }
            else
            {
                VertAbilityPatches.RestoreAnimController();
            }
        }

        private void Awake()
        {
            GTAPatchTC.Instance = this;
            this.configEntriesGround = new Dictionary<string, ConfigEntry<string>>
            {
                {
                    "skateboardGroundTrick0cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 0", "groundTrick0", "Button 1 trick")
                },
                {
                    "skateboardGroundTrick0Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 0 Name", "Kickflip", "Button 1 trick name")
                },
                {
                    "skateboardGroundTrick1cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 1", "groundTrick1", "Button 2 trick")
                },
                {
                    "skateboardGroundTrick1Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 1 Name", "720 Powerspin", "Button 2 trick name")
                },
                {
                    "skateboardGroundTrick2cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 2", "groundTrick2", "Button 3 trick")
                },
                {
                    "skateboardGroundTrick2Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Trick 2 Name", "360 Flip", "Button 3 trick name")
                },
                {
                    "skateboardGroundBoostTrick0cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 0", "groundBoostTrick0", "Button 1 boost trick")
                },
                {
                    "skateboardGroundBoostTrick0Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 0 Name", "Handstand Flip", "Button 1 boost trick name")
                },
                {
                    "skateboardGroundBoostTrick1cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 1", "groundTrick3", "Button 2 boost trick")
                },
                {
                    "skateboardGroundBoostTrick1Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 1 Name", "Impossible", "Button 2 boost trick name")
                },
                {
                    "skateboardGroundBoostTrick2cfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 2", "groundBoostTrick2", "Button 3 boost trick")
                },
                {
                    "skateboardGroundBoostTrick2Namecfg",
                    base.Config.Bind<string>("Skateboard Ground Tricks", "Skateboard Boost Trick 2 Name", "Handstand Flip", "Button 3 boost trick name")
                },
                {
                    "inlineGroundTrick0cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 0", "groundTrick0", "Button 1 trick")
                },
                {
                    "inlineGroundTrick0Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 0 Name", "Unity Spin Cess Slide", "Button 1 trick name")
                },
                {
                    "inlineGroundTrick1cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 1", "groundTrick1", "Button 2 trick")
                },
                {
                    "inlineGroundTrick1Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 1 Name", "Duckwalk Fakie", "Button 2 trick name")
                },
                {
                    "inlineGroundTrick2cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 2", "groundTrick2", "Button 3 trick")
                },
                {
                    "inlineGroundTrick2Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Trick 2 Name", "Back Closed Tree", "Button 3 trick name")
                },
                {
                    "inlineGroundBoostTrick0cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 0", "groundBoostTrick0", "Button 1 boost trick")
                },
                {
                    "inlineGroundBoostTrick0Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 0 Name", "Bio", "Button 1 boost trick name")
                },
                {
                    "inlineGroundBoostTrick1cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 1", "grindBoostTrick0", "Button 2 boost trick")
                },
                {
                    "inlineGroundBoostTrick1Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 1 Name", "Topside Pornstar", "Button 2 boost trick name")
                },
                {
                    "inlineGroundBoostTrick2cfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 2", "groundBoostTrick2", "Button 3 boost trick")
                },
                {
                    "inlineGroundBoostTrick2Namecfg",
                    base.Config.Bind<string>("Inline Ground Tricks", "Inline Boost Trick 2 Name", "Bio", "Button 3 boost trick name")
                },
                {
                    "bmxGroundTrick0cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 0", "groundTrick0", "Button 1 trick")
                },
                {
                    "bmxGroundTrick0Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 0 Name", "Cyclone", "Button 1 trick name")
                },
                {
                    "bmxGroundTrick1cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 1", "groundTrick1", "Button 2 trick")
                },
                {
                    "bmxGroundTrick1Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 1 Name", "Knoll Spin", "Button 2 trick name")
                },
                {
                    "bmxGroundTrick2cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 2", "groundTrick2", "Button 3 trick")
                },
                {
                    "bmxGroundTrick2Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Trick 2 Name", "Stubble Duck", "Button 3 trick name")
                },
                {
                    "bmxGroundBoostTrick0cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 0", "groundBoostTrick0", "Button 1 boost trick")
                },
                {
                    "bmxGroundBoostTrick0Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 0 Name", "Around The World", "Button 1 boost trick name")
                },
                {
                    "bmxGroundBoostTrick1cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 1", "groundBoostTrick1", "Button 2 boost trick")
                },
                {
                    "bmxGroundBoostTrick1Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 1 Name", "Around The World", "Button 2 boost trick name")
                },
                {
                    "bmxGroundBoostTrick2cfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 2", "groundBoostTrick2", "Button 3 boost trick")
                },
                {
                    "bmxGroundBoostTrick2Namecfg",
                    base.Config.Bind<string>("BMX Ground Tricks", "Bmx Boost Trick 2 Name", "Around The World", "Button 3 boost trick name")
                },
                {
                    "footGroundTrick0cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 0", "groundTrick0", "Button 1 trick")
                },
                {
                    "footGroundTrick0Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 0 Name", "Hook Kick", "Button 1 trick name")
                },
                {
                    "footGroundTrick1cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 1", "groundTrick1", "Button 2 trick")
                },
                {
                    "footGroundTrick1Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 1 Name", "Cartwheel", "Button 2 trick name")
                },
                {
                    "footGroundTrick2cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 2", "groundTrick2", "Button 3 trick")
                },
                {
                    "footGroundTrick2Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Trick 2 Name", "Back Sweep", "Button 3 trick name")
                },
                {
                    "footGroundBoostTrick0cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 0", "groundBoostTrick0", "Button 1 boost trick")
                },
                {
                    "footGroundBoostTrick0Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 0 Name", "Coin Drop", "Button 1 boost trick name")
                },
                {
                    "footGroundBoostTrick1cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 1", "groundBoostTrick1", "Button 2 boost trick")
                },
                {
                    "footGroundBoostTrick1Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 1 Name", "Coin Drop", "Button 2 boost trick name")
                },
                {
                    "footGroundBoostTrick2cfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 2", "groundBoostTrick2", "Button 3 boost trick")
                },
                {
                    "footGroundBoostTrick2Namecfg",
                    base.Config.Bind<string>("On-foot Ground Tricks", "Foot Boost Trick 2 Name", "Coin Drop", "Button 3 boost trick name")
                }
            };
            //CONTROLLER OVERRIDES
            IdleOverrides["skateboardGroundTrick0cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 trick").Value;
            IdleOverrides["skateboardGroundTrick1cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 trick").Value;
            IdleOverrides["skateboardGroundTrick2cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 trick").Value;
            IdleOverrides["skateboardGroundBoostTrick0cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Boost Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 boost trick").Value;
            IdleOverrides["skateboardGroundBoostTrick1cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Boost Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 boost trick").Value;
            IdleOverrides["skateboardGroundBoostTrick2cfgAnim"] = Config.Bind("Skateboard Ground Tricks", "Skateboard Boost Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 boost trick").Value;

            IdleOverrides["inlineGroundTrick0cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 trick").Value;
            IdleOverrides["inlineGroundTrick1cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 trick").Value;
            IdleOverrides["inlineGroundTrick2cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 trick").Value;
            IdleOverrides["inlineGroundBoostTrick0cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Boost Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 boost trick").Value;
            IdleOverrides["inlineGroundBoostTrick1cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Boost Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 boost trick").Value;
            IdleOverrides["inlineGroundBoostTrick2cfgAnim"] = Config.Bind("Inline Ground Tricks", "Inline Boost Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 boost trick").Value;

            IdleOverrides["bmxGroundTrick0cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 trick").Value;
            IdleOverrides["bmxGroundTrick1cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 trick").Value;
            IdleOverrides["bmxGroundTrick2cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 trick").Value;
            IdleOverrides["bmxGroundBoostTrick0cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Boost Trick 0 Override Anim", false, "Set to on-foot animator for Button 1 boost trick").Value;
            IdleOverrides["bmxGroundBoostTrick1cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Boost Trick 1 Override Anim", false, "Set to on-foot animator for Button 2 boost trick").Value;
            IdleOverrides["bmxGroundBoostTrick2cfgAnim"] = Config.Bind("BMX Ground Tricks", "Bmx Boost Trick 2 Override Anim", false, "Set to on-foot animator for Button 3 boost trick").Value;
        }

        public string GetConfigValueGround(string key)
        {
            ConfigEntry<string> configEntry;
            bool flag = this.configEntriesGround.TryGetValue(key, out configEntry);
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

        [HarmonyPatch(typeof(GroundTrickAbility), "Init")]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        private static bool Init_Prefix(GroundTrickAbility __instance)
        {
            bool flag = GTAPatchTC.Instance == null;
            bool result;
            if (flag)
            {
                Console.WriteLine("ATAPatchTC.Instance is null in Init_Prefix.");
                result = true;
            }
            else
            {
                string configValueGround = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick0Namecfg");
            string configValueGround2 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick1Namecfg");
            string configValueGround3 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick2Namecfg");
            string configValueGround4 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick0Namecfg");
            string configValueGround5 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick1Namecfg");
            string configValueGround6 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick2Namecfg");
            string configValueGround7 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick0Namecfg");
            string configValueGround8 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick1Namecfg");
            string configValueGround9 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick2Namecfg");
            string configValueGround10 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick0Namecfg");
            string configValueGround11 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick1Namecfg");
            string configValueGround12 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick2Namecfg");
            string configValueGround13 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick0Namecfg");
            string configValueGround14 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick1Namecfg");
            string configValueGround15 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick2Namecfg");
            string configValueGround16 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick0Namecfg");
            string configValueGround17 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick1Namecfg");
            string configValueGround18 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick2Namecfg");
            string configValueGround19 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick0Namecfg");
            string configValueGround20 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick1Namecfg");
            string configValueGround21 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick2Namecfg");
            string configValueGround22 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick0Namecfg");
            string configValueGround23 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick1Namecfg");
            string configValueGround24 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick2Namecfg");
            __instance.skateboardTrickNames = new string[]
            {
                    configValueGround,
                    configValueGround2,
                    configValueGround3,
                    configValueGround4,
                    configValueGround5,
                    configValueGround6
            };
            __instance.inlineSkatesTrickNames = new string[]
            {
                    configValueGround7,
                    configValueGround8,
                    configValueGround9,
                    configValueGround10,
                    configValueGround11,
                    configValueGround12
            };
            __instance.bmxTrickNames = new string[]
            {
                    configValueGround13,
                    configValueGround14,
                    configValueGround15,
                    configValueGround16,
                    configValueGround17,
                    configValueGround18
            };
            __instance.trickingTrickNames = new string[]
            {
                    configValueGround19,
                    configValueGround20,
                    configValueGround21,
                    configValueGround22,
                    configValueGround23,
                    configValueGround24
            };
                result = true;
            }
            return result;
        }
        [HarmonyPatch(typeof(GroundTrickAbility), "DoBoostTrick")]
        [HarmonyPrefix]
        private static bool DoBoostTrick_Prefix(GroundTrickAbility __instance)
        {
            if (GTAPatchTC.Instance == null)
            {
                Debug.LogError("GTAPatchTC.Instance is null! Retrying...");
                return true;
            }
            string configValueGround = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick0cfg");
            string configValueGround2 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick1cfg");
            string configValueGround3 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundBoostTrick2cfg");
            string configValueGround4 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick0cfg");
            string configValueGround5 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick1cfg");
            string configValueGround6 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundBoostTrick2cfg");
            string configValueGround7 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick0cfg");
            string configValueGround8 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick1cfg");
            string configValueGround9 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundBoostTrick2cfg");
            string configValueGround10 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick0cfg");
            string configValueGround11 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick1cfg");
            string configValueGround12 = GTAPatchTC.Instance.GetConfigValueGround("footGroundBoostTrick2cfg");

            if (__instance.p == null)
            {
                Debug.LogError("Player (p) is null!");
                return true;
            }

            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
            {
                if (__instance.curTrick == 0 && configValueGround != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundBoostTrick0cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround), true, false, 0f);
                }
                else if (configValueGround == null)
                {
                    Debug.LogError("Config value for skateboardGroundBoostTrick0cfg is null!");
                }

                if (__instance.curTrick == 1 && configValueGround2 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundBoostTrick1cfgAnim"]);
 
                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround2), true, false, 0f);
                }
                else if (configValueGround2 == null)
                {
                    Debug.LogError("Config value for skateboardGroundBoostTrick1cfg is null!");
                }

                if (__instance.curTrick == 2 && configValueGround3 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundBoostTrick2cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround3), true, false, 0f);
                }
                else if (configValueGround3 == null)
                {
                    Debug.LogError("Config value for skateboardGroundBoostTrick2cfg is null!");
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                if (__instance.curTrick == 0 && configValueGround4 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundBoostTrick0cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround4), true, false, 0f);
                }
                else if (configValueGround4 == null)
                {
                    Debug.LogError("Config value for inlineGroundBoostTrick0cfg is null!");
                }

                if (__instance.curTrick == 1 && configValueGround5 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundBoostTrick1cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround5), true, false, 0f);
                }
                else if (configValueGround5 == null)
                {
                    Debug.LogError("Config value for inlineGroundBoostTrick1cfg is null!");
                }

                if (__instance.curTrick == 2 && configValueGround6 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundBoostTrick2cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround6), true, false, 0f);
                }
                else if (configValueGround6 == null)
                {
                    Debug.LogError("Config value for inlineGroundBoostTrick2cfg is null!");
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                if (__instance.curTrick == 0 && configValueGround7 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundBoostTrick0cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround7), true, false, 0f);
                }
                else if (configValueGround7 == null)
                {
                    Debug.LogError("Config value for bmxGroundBoostTrick0cfg is null!");
                }

                if (__instance.curTrick == 1 && configValueGround8 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundBoostTrick1cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround8), true, false, 0f);
                }
                else if (configValueGround8 == null)
                {
                    Debug.LogError("Config value for bmxGroundBoostTrick1cfg is null!");
                }

                if (__instance.curTrick == 2 && configValueGround9 != null)
                {
                    CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundBoostTrick2cfgAnim"]);

                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround9), true, false, 0f);
                }
                else if (configValueGround9 == null)
                {
                    Debug.LogError("Config value for bmxGroundBoostTrick2cfg is null!");
                }
            }
            else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
            {
                if (__instance.curTrick == 0 && configValueGround10 != null)
                {
                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround10), true, false, 0f);
                }
                else if (configValueGround10 == null)
                {
                    Debug.LogError("Config value for footGroundBoostTrick0cfg is null!");
                }

                if (__instance.curTrick == 1 && configValueGround11 != null)
                {
                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround11), true, false, 0f);
                }
                else if (configValueGround11 == null)
                {
                    Debug.LogError("Config value for footGroundBoostTrick1cfg is null!");
                }

                if (__instance.curTrick == 2 && configValueGround12 != null)
                {
                    __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround12), true, false, 0f);
                }
                else if (configValueGround12 == null)
                {
                    Debug.LogError("Config value for footGroundBoostTrick2cfg is null!");
                }
            }
            //MOVESTYLER FIX
            else if (VertAbilityPatches.nonVanillaMovestyle)
            {
                __instance.p.PlayAnim(__instance.groundBoostTrickHashes[__instance.curTrick], true, false, 0f);
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
        [HarmonyPatch(typeof(GroundTrickAbility), "OnStartAbility")]
        [HarmonyPrefix]
        private static bool OnStartAbility_Prefix(GroundTrickAbility __instance)
        {
            if (GTAPatchTC.Instance == null)
            {
                Debug.LogError("GTAPatchTC.Instance is null! Retrying...");
                return true;
            }

            string configValueGround = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick0cfg");
            string configValueGround2 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick1cfg");
            string configValueGround3 = GTAPatchTC.Instance.GetConfigValueGround("skateboardGroundTrick2cfg");
            string configValueGround4 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick0cfg");
            string configValueGround5 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick1cfg");
            string configValueGround6 = GTAPatchTC.Instance.GetConfigValueGround("inlineGroundTrick2cfg");
            string configValueGround7 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick0cfg");
            string configValueGround8 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick1cfg");
            string configValueGround9 = GTAPatchTC.Instance.GetConfigValueGround("bmxGroundTrick2cfg");
            string configValueGround10 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick0cfg");
            string configValueGround11 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick1cfg");
            string configValueGround12 = GTAPatchTC.Instance.GetConfigValueGround("footGroundTrick2cfg");

            __instance.hitEnemy = false;
            __instance.duration = 0.75f;
            if (__instance.p.moveStyle == MoveStyle.SKATEBOARD || __instance.p.moveStyle == MoveStyle.SPECIAL_SKATEBOARD)
            {
                __instance.duration = 0.8431f;
            }
            else if (__instance.p.moveStyle == MoveStyle.BMX)
            {
                __instance.duration = 0.862f;
            }
            else if (__instance.p.moveStyle == MoveStyle.INLINE)
            {
                __instance.duration = 0.75f;
            }
            __instance.defaultSpeed = __instance.p.maxMoveSpeed * 0.62f;
            __instance.curTrick = __instance.p.InputToTrickNumber();
            __instance.curTrickDir = __instance.trickingHitDir[__instance.curTrick];
            __instance.targetSpeed = __instance.defaultSpeed;
            __instance.rotateSpeed = 3f;
            __instance.acc = 35f;
            __instance.decc = __instance.p.stats.groundDecc / 2.5f;
            __instance.trickCount = 1;
            if (__instance.p.GetForwardSpeed() < __instance.defaultSpeed)
            {
                __instance.p.SetForwardSpeed(__instance.defaultSpeed);
            }
            __instance.wantToStop = (__instance.stopDecided = (__instance.reTrickFail = false));
            if (!__instance.p.IsComboing())
            {
                __instance.p.RefillComboTimeOut();
            }
            __instance.boostTrick = false;
            if (!__instance.p.isAI && __instance.p.CheckBoostTrick())
            {
                __instance.DoBoostTrick();
            }
            else
            {
                if (__instance.p.moveStyle == MoveStyle.SKATEBOARD)
                {
                    if (__instance.curTrick == 0 && configValueGround != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround), true, false, 0f);
                    }
                    else if (configValueGround == null)
                    {
                        Debug.LogError("Config value for skateboardGroundBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueGround2 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround2), true, false, 0f);
                    }
                    else if (configValueGround2 == null)
                    {
                        Debug.LogError("Config value for skateboardGroundBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueGround3 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["skateboardGroundTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround3), true, false, 0f);
                    }
                    else if (configValueGround3 == null)
                    {
                        Debug.LogError("Config value for skateboardGroundBoostTrick2cfg is null!");
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.INLINE)
                {
                    if (__instance.curTrick == 0 && configValueGround4 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround4), true, false, 0f);
                    }
                    else if (configValueGround4 == null)
                    {
                        Debug.LogError("Config value for inlineGroundBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueGround5 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround5), true, false, 0f);
                    }
                    else if (configValueGround5 == null)
                    {
                        Debug.LogError("Config value for inlineGroundBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueGround6 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["inlineGroundTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround6), true, false, 0f);
                    }
                    else if (configValueGround6 == null)
                    {
                        Debug.LogError("Config value for inlineGroundBoostTrick2cfg is null!");
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.BMX)
                {
                    if (__instance.curTrick == 0 && configValueGround7 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundTrick0cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround7), true, false, 0f);
                    }
                    else if (configValueGround7 == null)
                    {
                        Debug.LogError("Config value for bmxGroundBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueGround8 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundTrick1cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround8), true, false, 0f);
                    }
                    else if (configValueGround8 == null)
                    {
                        Debug.LogError("Config value for bmxGroundBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueGround9 != null)
                    {
                        CheckAnimOverride(GTAPatchTC.IdleOverrides["bmxGroundTrick2cfgAnim"]);

                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround9), true, false, 0f);
                    }
                    else if (configValueGround9 == null)
                    {
                        Debug.LogError("Config value for bmxGroundBoostTrick2cfg is null!");
                    }
                }
                else if (__instance.p.moveStyle == MoveStyle.ON_FOOT)
                {
                    if (__instance.curTrick == 0 && configValueGround10 != null)
                    {
                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround10), true, false, 0f);
                    }
                    else if (configValueGround10 == null)
                    {
                        Debug.LogError("Config value for footGroundBoostTrick0cfg is null!");
                    }

                    if (__instance.curTrick == 1 && configValueGround11 != null)
                    {
                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround11), true, false, 0f);
                    }
                    else if (configValueGround11 == null)
                    {
                        Debug.LogError("Config value for footGroundBoostTrick1cfg is null!");
                    }

                    if (__instance.curTrick == 2 && configValueGround12 != null)
                    {
                        __instance.p.PlayAnim(AnimationUtility.GetAnimationByName(configValueGround12), true, false, 0f);
                    }
                    else if (configValueGround12 == null)
                    {
                        Debug.LogError("Config value for footGroundBoostTrick2cfg is null!");
                    }
                }
                //MOVESTYLER FIX
                else if (VertAbilityPatches.nonVanillaMovestyle)
                {
                    __instance.p.PlayAnim(__instance.groundTrickHashes[__instance.curTrick], true, false, 0f);
                }
            }
            __instance.p.hitboxLeftLeg.SetActive(false);
            __instance.p.hitboxRightLeg.SetActive(false);
            __instance.p.hitboxUpperBody.SetActive(false);
            if (!__instance.p.isAI)
            {
                __instance.p.StartClosestCheckEnemyForAutoAim();
            }

            return false;
        }

    }
}
