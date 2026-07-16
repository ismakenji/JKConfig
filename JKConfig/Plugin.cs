using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using JLL.API;

namespace JKConfig
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("JacobG5.JLL", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("imabatby.lethallevelloader", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "JacobG5.JKConfig";
        private const string modName = "JKConfig";
        private const string modVersion = "0.1.0";

        internal static ManualLogSource mls;
        internal static List<JKConfigFile> configFiles = [];

        public void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            JFileHelper.OnJLLBundlesLoaded.AddListener(PostModLoad);

            mls.LogInfo($"Kenji is evil");
        }

        private void PostModLoad()
        {
            try
            {
                foreach (JKConfigFile file in configFiles)
                {
                    file.ApplyConfigs();
                }
            }
            catch (Exception ex)
            {
                mls.LogError($"Whoopsie bad happened: {ex}");
            }
        }
    }
}
