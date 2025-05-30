using Infrastructure.Services.AssetManagement;
using UI.Configs;

namespace Gameplay.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WINDOWS_PATH = "StaticData/WindowData";
        
        private readonly IAssetProvider _assetProvider;

        public WindowStaticData WindowData { get; private set; }

        public StaticDataService(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void LoadAll()
        {
            LoadWindowStaticData();
        }

        private void LoadWindowStaticData() => 
            WindowData = _assetProvider.Load<WindowStaticData>(WINDOWS_PATH);
    }
}