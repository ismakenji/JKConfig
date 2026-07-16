using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using JLL.API;
using JLL.ScriptableObjects;
using UnityEngine;

namespace JKConfig
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("JacobG5.JLL", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("imabatby.lethallevelloader", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "rectorado.JKConfig";
        private const string modName = "JKConfig";
        private const string modVersion = "0.1.0";

        internal static ManualLogSource mls;
        internal static List<JKConfigFile> configFiles = [];

        public void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            JFileHelper.OnJLLBundlesLoaded.AddListener(ConfigFilesLoader.LoadConfigs);

            mls.LogInfo($"This thing has loaded supposedly!");
        }
    }
}