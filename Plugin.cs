using BepInEx;
using HarmonyLib;
using trickyclown;
using Reptile;
using System;
using UnityEngine;
using newtrickx;
using CarJack.Common;
using UnityEngine.SceneManagement;
using BepInEx.Configuration;
using BepInEx.Bootstrap;

namespace trickyclown
{
    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.4.1")]
    [BepInDependency("com.Dragsun.BunchOfEmotes", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class VertAbilityPatches : BaseUnityPlugin
    {
        private bool sceneLoaded = false;

        public static bool overridingIdle = false;

        private void Awake()
        {
            var harmony = new Harmony("info.mariobluegloves.trickyclownp");
            harmony.PatchAll(typeof(GTAPatchTC));
            harmony.PatchAll(typeof(ATAPatchTC));
            harmony.PatchAll(typeof(GriTAPatchTC));
            harmony.PatchAll(typeof(BPatchTC));
            harmony.PatchAll(typeof(SlideAbilityPatches));
            harmony.PatchAll(typeof(WallrunLineAbilityPatches));
            harmony.PatchAll(typeof(DoTrickPatch));
            harmony.PatchAll();
            Logger.LogInfo($"Trix R 4 Kidz");
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (Chainloader.PluginInfos.ContainsKey("com.Dragsun.BunchOfEmotes"))
            {
                BunchOfEmotesSupport.Initialize();
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
        }

        void Update()
        {
            if (sceneLoaded)
            {
                GameObject playerHuman0 = GameObject.Find("Player_HUMAN0");
                string goon = BPatchTC.Instance.GetConfigValueMisc("goonCfg");
                string goonInline = BPatchTC.Instance.GetConfigValueMisc("goonInlineCfg");
                string goonSkateboard = BPatchTC.Instance.GetConfigValueMisc("goonSkateboardCfg");
                string goonBMX = BPatchTC.Instance.GetConfigValueMisc("goonBMXCfg");

                if (playerHuman0 != null)
                {
                    Player p = playerHuman0.GetComponent<Player>();
                    if (p != null)
                    {
                        if (p.IsGrounded()) { VertAbilityPatches.overridingIdle = false; }

                        WallrunLineAbilityPatches.postWallrunTimer += Time.deltaTime;

                        if (WallrunLineAbilityPatches.postWallrunTimer > 100f)
                        {
                            WallrunLineAbilityPatches.postWallrunTimer = 100f;
                        }

                        if ((WallrunLineAbilityPatches.postWallrunTimer >= 0.1125f) && (WallrunLineAbilityPatches.hasWallRan == true) && (WallrunLineAbilityPatches.wallrunDuration <= Time.deltaTime))
                        {
                            WallrunLineAbilityPatches.hasWallRan = false;

                            WallrunLineAbility wallrunLineAbility = new WallrunLineAbility(p);
                            wallrunLineAbility.p.DoTrick(Player.TrickType.NONE, "Frameride", 0);
                            VertAbilityPatches.overridingIdle = true;
                            //Console.WriteLine("overridingIdle = true");
                            if (wallrunLineAbility.p.moveStyle == MoveStyle.INLINE)
                            {
                                wallrunLineAbility.p.PlayAnim(AnimationUtility.GetAnimationByName(goonInline), false, false, -1f);
                            }
                            else if (wallrunLineAbility.p.moveStyle == MoveStyle.SKATEBOARD)
                            {
                                wallrunLineAbility.p.PlayAnim(AnimationUtility.GetAnimationByName(goonSkateboard), false, false, -1f);
                            }
                            else if (wallrunLineAbility.p.moveStyle == MoveStyle.BMX)
                            {
                                wallrunLineAbility.p.PlayAnim(AnimationUtility.GetAnimationByName(goonBMX), false, false, -1f);
                            }
                            else if (wallrunLineAbility.p.moveStyle == MoveStyle.ON_FOOT)
                            {
                                wallrunLineAbility.p.PlayAnim(AnimationUtility.GetAnimationByName(goon), false, false, -1f);
                            }

                            if (Core.Instance?.AudioManager != null)
                            {
                                Core.Instance.AudioManager.PlaySfxGameplay(SfxCollectionID.MenuSfx, AudioClipID.confirm, 0.125f);
                            }
                        }
                    }
                }
            }
        }
    }
}
