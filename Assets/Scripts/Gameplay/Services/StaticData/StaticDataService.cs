using System.Collections.Generic;
using System.Linq;
using Gameplay.Collects;
using Gameplay.Collects.Configs;
using Gameplay.Levels;
using Gameplay.Levels.Configs;
using Gameplay.Player.Configs;
using Infrastructure.AssetManagement;
using Logging;
using ModestTree;
using UI.Windows.Configs;

namespace Gameplay.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WINDOWS_PATH = "StaticData/UI/WindowData";
        private const string PLAYER_PATH = "StaticData/Gameplay/Players/PlayerConfig";
        private const string COLLECTIBLES_PATH = "StaticData/Gameplay/Collectibles";
        private const string LEVELS_PATH = "StaticData/Gameplay/Levels";
        
        private readonly IAssetProvider _assetProvider;

        public WindowStaticData WindowData { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }
        public Dictionary<CollectibleType, CollectibleConfig> Collectibles { get; private set; }
        public Dictionary<string, LevelTransferConfig> Levels { get; private set; }

        public StaticDataService(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void LoadAll()
        {
            LoadWindowData();
            LoadPlayerData();
            LoadCollectiblesData();
            LoadLevelTransferData();
        }

        private void LoadWindowData()
        {
            WindowData = _assetProvider.Load<WindowStaticData>(WINDOWS_PATH);
            if (!WindowData) throw new System.Exception("WindowData is null");
        }

        private void LoadPlayerData()
        {
            PlayerConfig = _assetProvider.Load<PlayerConfig>(PLAYER_PATH);
            if (!PlayerConfig) throw new System.Exception("PlayerConfig is null");
        }
        
        private void LoadCollectiblesData()
        {
            Collectibles = _assetProvider
                .LoadAll<CollectibleConfig>(COLLECTIBLES_PATH)
                .ToDictionary(x => x.Type, x => x);
            
            if (Collectibles.IsEmpty()) DebugLogger.LogWarning("Collectibles is empty");
        }

        private void LoadLevelTransferData()
        {
            Levels = _assetProvider
                .LoadAll<LevelTransferConfig>(LEVELS_PATH)
                .ToDictionary(x => x.LevelName, x => x);
            
            if (Levels.IsEmpty()) throw new System.Exception("Levels transfer is empty");
        }
    }
}