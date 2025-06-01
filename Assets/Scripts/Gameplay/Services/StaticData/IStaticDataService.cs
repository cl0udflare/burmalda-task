using System.Collections.Generic;
using Gameplay.Collects;
using Gameplay.Collects.Configs;
using Gameplay.Levels;
using Gameplay.Levels.Configs;
using Gameplay.Player.Configs;
using UI.Windows.Configs;

namespace Gameplay.Services.StaticData
{
    public interface IStaticDataService
    {
        WindowStaticData WindowData { get; }
        PlayerConfig PlayerConfig { get; }
        Dictionary<CollectibleType, CollectibleConfig> Collectibles { get; }
        Dictionary<string, LevelTransferConfig> Levels { get; }
        void LoadAll();
    }
}