using BepInEx;
using HarmonyLib;
using Reptile;
using System;
using UnityEngine;

namespace trickyclown
{
    [BepInPlugin("info.mariobluegloves.trickyclown", "New Trix", "1.0.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]

    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            var harmony = new Harmony("info.mariobluegloves.trickyclownp");
            harmony.PatchAll(typeof(GTAPatchTC));
            harmony.PatchAll(typeof(ATAPatchTC));
            Logger.LogInfo($"Trix R 4 Kidz");
        }
    }
}