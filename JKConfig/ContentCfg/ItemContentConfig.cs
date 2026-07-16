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
        float weight;
        bool twoHanded;
        bool isConductiveMetal;

        protected override void LoadCfg(bool isEnabled)
        {
            minValue = GetValue("MinValue", Content.Item.minValue, "The minimum value for the item. In-game it'll show the value multiplied by 0.4.");
            maxValue = GetValue("MaxValue", Content.Item.maxValue, "The maximum value for the item. In-game it'll show the value multiplied by 0.4.");
            weight = GetValue("Weight", Content.Item.weight, "The weight for the item.");
            twoHanded = GetValue("TwoHanded", Content.Item.twoHanded, "Indicates if the item is two-handed.");
            isConductiveMetal = GetValue("IsConductive", Content.Item.isConductiveMetal, "Indicates if the item is conductive.");

            // Level Weights Settings

            levelTags = GetValue("ItemInjectionSettingsByLevelTags", Content.LevelMatchingProperties.levelTags, "Add this Item to a Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            currentRoutePrice = GetValue("ItemInjectionSettingsByCurrentRoutePrice", Content.LevelMatchingProperties.currentRoutePrice, "Add this Item to a Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)")
                .ToList();
            currentWeather = GetValue("ItemInjectionSettingsByCurrentWeather", Content.LevelMatchingProperties.currentWeather, "Add this Item to a Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            planetNames = GetValue("ItemInjectionSettingsByPlanetNames", Content.LevelMatchingProperties.planetNames, "Add this Item to a Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

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
                Content.Item.weight = weight;
                Content.Item.twoHanded = twoHanded;
                Content.Item.isConductiveMetal = isConductiveMetal;
            }
        }
    }
}
