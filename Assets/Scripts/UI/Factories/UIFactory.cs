using Gameplay.Services.StaticData;
using Infrastructure.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_PATH = "UI/UIRoot";
        
        private GameObject _uiRoot;

        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticDataService;

        public UIFactory(IAssetProvider assetProvider, DiContainer container, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _container = container;
            _staticDataService = staticDataService;
        }

        public void CreateUIRoot()
        {
            GameObject uiRoot = _assetProvider.Load<GameObject>(UI_ROOT_PATH);
            _uiRoot = _container.InstantiatePrefab(uiRoot);
        }
    }
}