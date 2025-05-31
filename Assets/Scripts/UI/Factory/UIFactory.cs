using Gameplay.Services.StaticData;
using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace UI.Factory
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
            _uiRoot = Object.Instantiate(uiRoot);
        }
        
        public void CreateMainMenu()
        {
            GameObject mainMenu = _assetProvider.Load<GameObject>(MAIN_MENU_PATH);
            _mainMenu = Object.Instantiate(mainMenu, _uiRoot.transform);
            _container.InjectGameObject(_mainMenu);
        }
    }
}