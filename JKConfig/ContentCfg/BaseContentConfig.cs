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

        public bool GetValue(string propertyName, bool defaultValue, string description = "")
        {
            return _file.Bind(Content.name, propertyName, defaultValue, description).Value;
        }

        public int GetValue(string propertyName, int defaultValue, string description = "")
        {
            return _file.Bind(Content.name, propertyName, defaultValue, description).Value;
        }

        public float GetValue(string propertyName, float defaultValue, string description = "")
        {
            return _file.Bind(Content.name, propertyName, defaultValue, description).Value;
        }

        public string Stringify(IEnumerable<StringWithRarity> properties)
        {
            return string.Join(',', properties.Select(x => $"{x.Name}:{x.Rarity}"));
        }

        public IEnumerable<StringWithRarity> ParseSwr(string config)
        {
            string[] split = config.Split(',');
            foreach (string s in split)
            {
                string[] v = s.Trim().Split(':');
                if (v.Length > 1 && int.TryParse(v[1], out int rarity))
                {
                    yield return new StringWithRarity(v[0].Trim(), rarity);
                }
            }
        }

        public IEnumerable<StringWithRarity> GetValue(string propertyName, IEnumerable<StringWithRarity> defaultValue, string description = "")
        {
            return ParseSwr(_file.Bind(Content.name, propertyName, Stringify(defaultValue), description).Value);
        }

        public string Stringify(IEnumerable<Vector2WithRarity> properties)
        {
            return string.Join(',', properties.Select(x => $"{x.Min}-{x.Max}:{x.Rarity}"));
        }

        // min-max-rarity, min-max-rarity, min-max-rarity,
        public IEnumerable<Vector2WithRarity> ParseV2wr(string config)
        {
            string[] split = config.Split(',');
            foreach (string s in split)
            {
                string[] v = s.Trim().Split(':');
                string[] minMax = v[0].Trim().Split('-');

                if (
                    v.Length > 1
                    && float.TryParse(minMax[0], out float x)
                    && float.TryParse(minMax[1], out float y)
                    && int.TryParse(v[1], out int rarity)
                )
                {
                    yield return new Vector2WithRarity(x, y, rarity);
                }
            }
        }

        public IEnumerable<Vector2WithRarity> GetValue(string propertyName, IEnumerable<Vector2WithRarity> defaultValue, string description = "")
        {
            return ParseV2wr(_file.Bind(Content.name, propertyName, Stringify(defaultValue), description).Value);
        }
    }
}
