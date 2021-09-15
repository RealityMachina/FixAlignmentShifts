using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker.Blueprints.JsonSystem;
//using Kingmaker.Blueprints.JsonSystem;

using UnityEngine;
using UnityModManagerNet;
using Kingmaker.Localization;
using static UnityModManagerNet.UnityModManager;

namespace FixAlignmentShifts
{
    public class Main
    {
        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
            var harmony = new Harmony(modEntry.Info.Id);

            savedModEntry = modEntry;
           // ModSettings.LoadAllSettings();
            //modEntry.OnGUI = new Action<UnityModManager.ModEntry>(Main.OnGUI);
            //   modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(Main.OnSaveGUI);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
           // PostPatchInitializer.Initialize();
            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Main.iAmEnabled = value;
            return true;
        }

        public static void Log(string msg)
        {
            savedModEntry.Logger.Log(msg);
        }

        private static bool iAmEnabled;

        public static ModEntry savedModEntry;
    }
}
