using System;
using System.Collections.Generic;
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

        protected override void LoadCfg()
        {
            Content.Item.minValue = GetValue("MinValue", Content.Item.minValue, "This is a description");
            Content.Item.maxValue = GetValue("MaxValue", Content.Item.maxValue, "This is a description");

            levelTags = GetValue("LevelTags", Content.LevelMatchingProperties.levelTags, "This is a description");
            currentRoutePrice = GetValue("CurrentRoutePrice", Content.LevelMatchingProperties.currentRoutePrice, "This is a description");
            currentWeather = GetValue("CurrentWeather", Content.LevelMatchingProperties.currentWeather, "This is a description");
            planetNames = GetValue("PlanetNames", Content.LevelMatchingProperties.planetNames, "This is a description");

            Content.LevelMatchingProperties.ApplyValues(
                newLevelTags: levelTags,
                newRoutePrices: currentRoutePrice,
                newCurrentWeathers: currentWeather,
                newPlanetNames: planetNames
            );
        }
    }
}