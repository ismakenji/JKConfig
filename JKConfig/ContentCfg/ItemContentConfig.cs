using LethalLevelLoader;
using System;

namespace JKConfig.ContentCfg
{
    [Serializable]
    public class ItemContentConfig : BaseContentConfig<ExtendedItem>
    {
        protected override void LoadCfg()
        {
            Content.Item.twoHanded = GetValue("TwoHanded", Content.Item.twoHanded, "This is a description");
        }
    }
}
