using BepInEx.Configuration;
using LethalLevelLoader;

namespace JKConfig.ContentCfg
{
    public abstract class BaseContentConfig<T> where T : ExtendedContent
    {
        public T Content;
        private ConfigFile _file;

        public bool Load(ConfigFile file)
        {
            if (Content == null) return false;
            _file = file;
            if (GetValue("Enabled", false, "Enables configuration of this content's properties."))
            {
                LoadCfg();
                return true;
            }
            return false;
        }

        protected abstract void LoadCfg();

        public V GetValue<V>(string propertyName, V defaultValue, string description = "")
        {
            return _file.Bind(Content.name, propertyName, defaultValue, description).Value;
        }
    }
}
