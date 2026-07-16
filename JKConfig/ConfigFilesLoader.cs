using System;

namespace JKConfig
{
    public static class ConfigFilesLoader
    {
        public static void LoadConfigs()
        {
            Plugin.mls.LogInfo($"Applying configs for {Plugin.configFiles.Count} JKConfig files");

            try
            {
                foreach (JKConfigFile file in Plugin.configFiles)
                {
                    file.ApplyConfigs();
                }
            }
            catch (Exception ex)
            {
                Plugin.mls.LogError($"Whoopsie bad happened: {ex}");
            }
        }
    }
}
