using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
using LethalLevelLoader;

namespace JKConfig.ContentCfg
{
    public abstract class BaseContentConfig<T>
        where T : ExtendedContent
    {
        public T Content;
        private ConfigFile _file;

        public bool Load(ConfigFile file)
        {
            if (Content == null)
            {
                return false;
            }

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

        public string Stringify(IEnumerable<StringWithRarity> properties)
        {
            return string.Join(',', properties.Select(x => $"{x.Name}-{x.Rarity}"));
        }

        public IEnumerable<StringWithRarity> ParseSwr(string config)
        {
            string[] split = config.Split(',');
            foreach (string s in split)
            {
                string[] v = s.Trim().Split('-');
                if (v.Length > 1 && int.TryParse(v[1], out int rarity))
                {
                    yield return new StringWithRarity(v[0].Trim(), rarity);
                }
            }
        }

        public string Stringify(IEnumerable<Vector2WithRarity> properties)
        {
            return string.Join(',', properties.Select(x => $"{x.Min}-{x.Max}-{x.Rarity}"));
        }

        // min-max-rarity, min-max-rarity, min-max-rarity,
        public IEnumerable<Vector2WithRarity> ParseV2wr(string config)
        {
            string[] split = config.Split(',');
            foreach (string s in split)
            {
                string[] v = s.Trim().Split('-');
                if (v.Length > 2 && float.TryParse(v[0], out float x) && float.TryParse(v[1], out float y) && int.TryParse(v[2], out int rarity))
                {
                    yield return new Vector2WithRarity(x, y, rarity);
                }
            }
        }
    }
}
