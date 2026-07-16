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
            var outsideDefaults = Content?.OutsideLevelMatchingProperties;
            levelTags = GetValue("OutsideLevelSettingsByLevelTags", outsideDefaults?.levelTags ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Outside Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            currentRoutePrice = GetValue("OutsideLevelSettingsByCurrentRoutePrice", outsideDefaults?.currentRoutePrice ?? Enumerable.Empty<Vector2WithRarity>(), "Add this Enemy to an Outside Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)").ToList();
            currentWeather = GetValue("OutsideLevelSettingsByCurrentWeather", outsideDefaults?.currentWeather ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Outside Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            planetNames = GetValue("OutsideLevelSettingsByPlanetNames", outsideDefaults?.planetNames ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Outside Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

            // Daytime Level Settings
            var daytimeDefaults = Content?.DaytimeLevelMatchingProperties;
            var daytimeLevelTags = GetValue("DaytimeLevelSettingsByLevelTags", daytimeDefaults?.levelTags ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to a Daytime Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            var daytimeRoutePrice = GetValue("DaytimeLevelSettingsByCurrentRoutePrice", daytimeDefaults?.currentRoutePrice ?? Enumerable.Empty<Vector2WithRarity>(), "Add this Enemy to a Daytime Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)").ToList();
            var daytimeWeather = GetValue("DaytimeLevelSettingsByCurrentWeather", daytimeDefaults?.currentWeather ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to a Daytime Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            var daytimePlanetNames = GetValue("DaytimeLevelSettingsByPlanetNames", daytimeDefaults?.planetNames ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to a Daytime Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

            // Inside Level Settings
            var insideDefaults = Content?.InsideLevelMatchingProperties;
            var insideLevelTags = GetValue("InsideLevelSettingsByLevelTags", insideDefaults?.levelTags ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Inside Level's randomisation pool based on matching Tag Names. (Minimum: 0, Maximum: 9999)").ToList();
            var insideRoutePrice = GetValue("InsideLevelSettingsByCurrentRoutePrice", insideDefaults?.currentRoutePrice ?? Enumerable.Empty<Vector2WithRarity>(), "Add this Enemy to an Inside Level's randomisation pool based on matching Route Prices. (Minimum: 0, Maximum: 9999)").ToList();
            var insideWeather = GetValue("InsideLevelSettingsByCurrentWeather", insideDefaults?.currentWeather ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Inside Level's randomisation pool based on matching Weather Conditions. (Minimum: 0, Maximum: 9999)").ToList();
            var insidePlanetNames = GetValue("InsideLevelSettingsByPlanetNames", insideDefaults?.planetNames ?? Enumerable.Empty<StringWithRarity>(), "Add this Enemy to an Inside Level's randomisation pool based on matching Level Names. (Minimum: 0, Maximum: 9999)").ToList();

            // Si está habilitado, aplicar sólo donde existan las propiedades destino
            if (isEnabled)
            {
                if (Content?.OutsideLevelMatchingProperties != null)
                {
                    Content.OutsideLevelMatchingProperties.ApplyValues(
                        newLevelTags: levelTags.ToList(),
                        newRoutePrices: currentRoutePrice.ToList(),
                        newCurrentWeathers: currentWeather.ToList(),
                        newPlanetNames: planetNames.ToList()
                    );
                }

                if (Content?.DaytimeLevelMatchingProperties != null)
                {
                    Content.DaytimeLevelMatchingProperties.ApplyValues(
                        newLevelTags: daytimeLevelTags.ToList(),
                        newRoutePrices: daytimeRoutePrice.ToList(),
                        newCurrentWeathers: daytimeWeather.ToList(),
                        newPlanetNames: daytimePlanetNames.ToList()
                    );
                }

                if (Content?.InsideLevelMatchingProperties != null)
                {
                    Content.InsideLevelMatchingProperties.ApplyValues(
                        newLevelTags: insideLevelTags.ToList(),
                        newRoutePrices: insideRoutePrice.ToList(),
                        newCurrentWeathers: insideWeather.ToList(),
                        newPlanetNames: insidePlanetNames.ToList()
                );

                    Content.EnemyType.PowerLevel = PowerLevel;
                    Content.EnemyType.MaxCount = MaxCount;
                }
            }
        }
    }
}
