using System.Collections.Generic;
using Gameplay.Services.StaticData;
using Infrastructure.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_PATH = "UI/UIRoot";
        private const string MAIN_MENU_PATH = "UI/MainMenu";

        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticDataService;

        private GameObject _uiRoot;
        private GameObject _mainMenu;
        
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
        
        public void CreateMainMenu()
        {
            GameObject mainMenu = _assetProvider.Load<GameObject>(MAIN_MENU_PATH);
            _mainMenu = _container.InstantiatePrefab(mainMenu, _uiRoot.transform);
        }

        public void Cleanup()
        {
            Object.Destroy(_uiRoot?.gameObject);
            Object.Destroy(_mainMenu?.gameObject);
        }
    }
}