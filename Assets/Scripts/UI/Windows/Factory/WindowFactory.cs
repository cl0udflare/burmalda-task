using Gameplay.Services.StaticData;
using UnityEngine;
using Zenject;

namespace UI.Windows.Factory
{
    public class WindowFactory : IWindowFactory
    {
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticData;

        private RectTransform _uiRoot;

        public WindowFactory(DiContainer container, IStaticDataService staticData)
        {
            _container = container;
            _staticData = staticData;
        }

        public void SetUIRoot(RectTransform uiRoot) =>
            _uiRoot = uiRoot;

        public WindowBase CreateWindow(WindowType type)
        {
            WindowBase window = Object.Instantiate(PrefabFor(type), _uiRoot);
            window.SetId(type);
            
            _container.InjectGameObject(window.gameObject);
            
            return window;
        }

        private WindowBase PrefabFor(WindowType type) =>
            _staticData.WindowData.GetWindowByType(type).Prefab;
    }
}