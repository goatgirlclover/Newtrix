using System;
using HarmonyLib;
using Reptile;
using trickyclown;
using UnityEngine;

namespace newtrickx
{
    [HarmonyPatch(typeof(VertAbility))]
    internal class VertAbilityPatches
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
                __instance.p.PlayAnim(airTrickAbility.airBoostTrickHashes[airTrickAbility.curTrick], false, false, -1f);
                bool flag0 = __instance.p.moveStyle == MoveStyle.SKATEBOARD;
                if (flag0)
                {
                    bool flag2 = airTrickAbility.curTrick == 0;
                    if (flag2)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirBoostTrick0), true, false, 0f);
                    }
                    bool flag3 = airTrickAbility.curTrick == 1;
                    if (flag3)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirBoostTrick1), true, false, 0f);
                    }
                    bool flag3b = airTrickAbility.curTrick == 2;
                    if (flag3b)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirBoostTrick2), true, false, 0f);
                    }
                }
                else
                {
                    bool flag4 = __instance.p.moveStyle == MoveStyle.INLINE;
                    if (flag4)
                    {
                        bool flag5 = airTrickAbility.curTrick == 0;
                        if (flag5)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirBoostTrick0), true, false, 0f);
                        }
                        bool flag5a = airTrickAbility.curTrick == 1;
                        if (flag5a)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirBoostTrick1), true, false, 0f);
                        }
                        bool flag6 = airTrickAbility.curTrick == 2;
                        if (flag6)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirBoostTrick2), true, false, 0f);
                        }
                    }
                }
                bool flag7 = __instance.p.moveStyle == MoveStyle.BMX;
                if (flag7)
                {
                    bool flag8 = airTrickAbility.curTrick == 0;
                    if (flag8)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(bmxAirBoostTrick0), true, false, 0f);
                    }
                    bool flag8a = airTrickAbility.curTrick == 1;
                    if (flag8a)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(bmxAirBoostTrick1), true, false, 0f);
                    }
                    bool flag9 = airTrickAbility.curTrick == 2;
                    if (flag9)
                    {
                        __instance.p.PlayAnim(Animator.StringToHash(bmxAirBoostTrick2), true, false, 0f);
                    }
                }
                else
                {
                    bool flag10 = __instance.p.moveStyle == MoveStyle.ON_FOOT;
                    if (flag10)
                    {
                        bool flag11 = airTrickAbility.curTrick == 0;
                        if (flag11)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrick0), true, false, 0f);
                        }
                        bool flag12 = airTrickAbility.curTrick == 1;
                        if (flag12)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrick1), true, false, 0f);
                        }
                        bool flag13 = airTrickAbility.curTrick == 2;
                        if (flag13)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirBoostTrick2), true, false, 0f);
                        }
                    }
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
                    bool flag5 = __instance.p.moveStyle == MoveStyle.ON_FOOT;
                    if (flag5)
                    {
                        bool flag6 = airTrickAbility.curTrick == 0;
                        if (flag6)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrick0), true, false, 0f);
                        }
                        bool flag6a = airTrickAbility.curTrick == 1;
                        if (flag6a)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrick1), true, false, 0f);
                        }
                        bool flag6b = airTrickAbility.curTrick == 2;
                        if (flag6b)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(footAirTrick2), true, false, 0f);
                        }
                    }
                    bool flagB = __instance.p.moveStyle == MoveStyle.BMX;
                    if (flagB)
                    {
                        bool flagB0 = airTrickAbility.curTrick == 0;
                        if (flagB0)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(bmxAirTrick0), true, false, 0f);
                        }
                        bool flagB1 = airTrickAbility.curTrick == 1;
                        if (flagB1)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(bmxAirTrick1), true, false, 0f);
                        }
                        bool flagB2 = airTrickAbility.curTrick == 2;
                        if (flagB2)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(bmxAirTrick2), true, false, 0f);
                        }
                    }
                    bool flag7 = __instance.p.moveStyle == MoveStyle.INLINE;
                    if (flag7)
                    {
                        bool flag8 = airTrickAbility.curTrick == 0;
                        if (flag8)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirTrick0), true, false, -1f);
                        }
                        bool flag8a = airTrickAbility.curTrick == 1;
                        if (flag8a)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirTrick1), true, false, -1f);
                        }
                        bool flag8b = airTrickAbility.curTrick == 2;
                        if (flag8b)
                        {
                            __instance.p.PlayAnim(Animator.StringToHash(inlineAirTrick2), true, false, -1f);
                        }
                    }
                    bool flag9 = __instance.p.moveStyle == MoveStyle.SKATEBOARD;
                    if (flag9)
                    {
                        bool flaga = airTrickAbility.curTrick == 0;
                        bool flage = airTrickAbility.curTrick == 1;
                        bool flagf = airTrickAbility.curTrick == 2;

                        if (flaga)
                        {
                            float moveAxisX = __instance.p.moveAxisX;
                            float moveAxisY = __instance.p.moveAxisY;

                            if (getTonyCfg)
                            {
                                if (moveAxisX <= -0.25f)
                                {
                                    if (moveAxisY <= -0.25f)
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                                    }
                                    else if (moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                                    }
                                    else
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash("groundTrick0"), true, false, -1f);
                                    }
                                }
                                else if (moveAxisX >= 0.25f)
                                {
                                    if (moveAxisY <= -0.25f)
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                                    }
                                    else if (moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                                    }
                                    else
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash("groundTrick2"), true, false, -1f);
                                    }
                                }
                                else if (moveAxisY <= -0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash("grindTrick0"), true, false, -1f);
                                }
                                else if (moveAxisY >= 0.25f)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash("groundTrick3"), true, false, -1f);
                                }
                                else
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                                }
                            }
                            else
                            {
                                __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick0), true, false, -1f);
                            }

                        }
                        if (flage)
                        {
                            if (getTonyCfg)
                            {
                                if (__instance.p.slideButtonHeld)
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash("groundBoostTrick0"), false, false, -1f);
                                }
                                else
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick1), false, false, -1f);
                                }
                            }
                            else
                            {
                                __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick1), false, false, -1f);
                            }
                        }
                        if (flagf)
                        {
                            if (getTonyCfg)
                            {
                                if (__instance.p.moveAxisX >= 0.25f)
                                {
                                    if (__instance.p.moveAxisY <= -0.25f)
                                    {
                                        Console.WriteLine("EVEN FLOOOOOW");
                                        __instance.p.PlayAnim(Animator.StringToHash("airBoostTrick2"), false, false, -1f);
                                    }
                                    else if (__instance.p.moveAxisY >= 0.25f)
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick2), false, false, -1f);
                                    }
                                    else
                                    {
                                        __instance.p.PlayAnim(Animator.StringToHash("airTrick1"), false, false, -1f);
                                    }
                                }
                                else
                                {
                                    __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick2), false, false, -1f);
                                }
                            }
                            else
                            {
                                __instance.p.PlayAnim(Animator.StringToHash(skateboardAirTrick2), false, false, -1f);
                            }
                        }
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
