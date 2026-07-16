using System;
using System.Collections.Generic;
using System.Linq;
using LethalLevelLoader;

namespace JKConfig.ContentCfg
{
    [Serializable]
    public class EnemyContentConfig : BaseContentConfig<ExtendedEnemyType>
    {
        List<StringWithRarity> levelTags = [];
        List<Vector2WithRarity> currentRoutePrice = [];
        List<StringWithRarity> currentWeather = [];
        List<StringWithRarity> planetNames = [];

        float PowerLevel;
        int MaxCount;

        protected override void LoadCfg(bool isEnabled)
        {
            PowerLevel = GetValue("PowerLevel", Content.EnemyType.PowerLevel, "The power level for the enemy.");
            MaxCount = GetValue("MaxCount", Content.EnemyType.MaxCount, "The maximum count for the enemy.");


            // Outside Level Settings

            levelTags = GetValue("OutsideLevelSettingsByLevelTags", Content.OutsideLevelMatchingProperties.levelTags, "Add this Enemy to an Outside Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            currentRoutePrice = GetValue("OutsideLevelSettingsByCurrentRoutePrice", Content.OutsideLevelMatchingProperties.currentRoutePrice, "Add this Enemy to an Outside Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)")
                .ToList();
            currentWeather = GetValue("OutsideLevelSettingsByCurrentWeather", Content.OutsideLevelMatchingProperties.currentWeather, "Add this Enemy to an Outside Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            planetNames = GetValue("OutsideLevelSettingsByPlanetNames", Content.OutsideLevelMatchingProperties.planetNames, "Add this Enemy to an Outside Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

            // Daytime Level Settings

            levelTags = GetValue("DaytimeLevelSettingsByLevelTags", Content.DaytimeLevelMatchingProperties.levelTags, "Add this Enemy to a Daytime Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            currentRoutePrice = GetValue("DaytimeLevelSettingsByCurrentRoutePrice", Content.DaytimeLevelMatchingProperties.currentRoutePrice, "Add this Enemy to a Daytime Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)")
                .ToList();
            currentWeather = GetValue("DaytimeLevelSettingsByCurrentWeather", Content.DaytimeLevelMatchingProperties.currentWeather, "Add this Enemy to a Daytime Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            planetNames = GetValue("DaytimeLevelSettingsByPlanetNames", Content.DaytimeLevelMatchingProperties.planetNames, "Add this Enemy to a Daytime Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

            // Inside Level Settings

            levelTags = GetValue("InsideLevelSettingsByLevelTags", Content.InsideLevelMatchingProperties.levelTags, "Add this Enemy to an Inside Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            currentRoutePrice = GetValue("InsideLevelSettingsByCurrentRoutePrice", Content.InsideLevelMatchingProperties.currentRoutePrice, "Add this Enemy to an Inside Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)")
                .ToList();
            currentWeather = GetValue("InsideLevelSettingsByCurrentWeather", Content.InsideLevelMatchingProperties.currentWeather, "Add this Enemy to an Inside Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            planetNames = GetValue("InsideLevelSettingsByPlanetNames", Content.InsideLevelMatchingProperties.planetNames, "Add this Enemy to an Inside Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();
            if (isEnabled)
            {
                Content.OutsideLevelMatchingProperties.ApplyValues(
                    newLevelTags: levelTags.ToList(),
                    newRoutePrices: currentRoutePrice.ToList(),
                    newCurrentWeathers: currentWeather.ToList(),
                    newPlanetNames: planetNames.ToList()
                );

                Content.EnemyType.PowerLevel = PowerLevel;
                Content.EnemyType.MaxCount = MaxCount;
            }
        }
    }
}
