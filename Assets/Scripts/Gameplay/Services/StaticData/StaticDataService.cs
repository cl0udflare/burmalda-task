using Gameplay.Player.Configs;
using Infrastructure.Services.AssetManagement;
using UI.Configs;

namespace Gameplay.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WINDOWS_PATH = "StaticData/UI/WindowData";
        private const string PLAYER_PATH = "StaticData/Gameplay/PlayerConfig";
        
        private readonly IAssetProvider _assetProvider;

        public WindowStaticData WindowData { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }

        public StaticDataService(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void LoadAll()
        {
            LoadWindowData();
            LoadPlayerData();
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
    }
}