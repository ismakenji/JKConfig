using BepInEx;
using BepInEx.Configuration;
using JKConfig.ContentCfg;
using JLL.ScriptableObjects;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JKConfig
{
    [CreateAssetMenu(menuName = "JLL/Addon/JKConfig")]
    public class JKConfigFile : JLLAddon
    {
        private ConfigFile File;

        public List<ItemContentConfig> Items = [];

        public override void Init(JLLMod parent)
        {
            File = new ConfigFile(Path.Combine(Paths.ConfigPath, "JKConfig", $"{parent.GUID()}.cfg"), true);
            Plugin.configFiles.Add(this);
        }

        internal void ApplyConfigs()
        {
            int i = 0;

            foreach (var cfg in Items) if (cfg.Load(File)) i++;

            File.Save();
            Plugin.mls.LogInfo($"Applied {i}: {File.ConfigFilePath}");
        }
    }
}
