using System;
using System.Collections.Generic;
using System.Linq;
using LethalLevelLoader;

namespace JKConfig.ContentCfg
{
    [Serializable]
    public class ItemContentConfig : BaseContentConfig<ExtendedItem>
    {
        List<StringWithRarity> levelTags = [];
        List<Vector2WithRarity> currentRoutePrice = [];
        List<StringWithRarity> currentWeather = [];
        List<StringWithRarity> planetNames = [];

        int minValue;
        int maxValue;

        protected override void LoadCfg(bool isEnabled)
        {
            minValue = GetValue("MinValue", Content.Item.minValue, "This is a description");
            maxValue = GetValue("MaxValue", Content.Item.maxValue, "This is a description");

            levelTags = GetValue("LevelTags", Content.LevelMatchingProperties.levelTags, "This is a description").ToList();
            currentRoutePrice = GetValue("CurrentRoutePrice", Content.LevelMatchingProperties.currentRoutePrice, "This is a description")
                .ToList();
            currentWeather = GetValue("CurrentWeather", Content.LevelMatchingProperties.currentWeather, "This is a description").ToList();
            planetNames = GetValue("PlanetNames", Content.LevelMatchingProperties.planetNames, "This is a description").ToList();

            if (isEnabled)
            {
                Content.LevelMatchingProperties.ApplyValues(
                    newLevelTags: levelTags.ToList(),
                    newRoutePrices: currentRoutePrice.ToList(),
                    newCurrentWeathers: currentWeather.ToList(),
                    newPlanetNames: planetNames.ToList()
                );

                Content.Item.minValue = minValue;
                Content.Item.maxValue = maxValue;
            }
        }
    }
}
