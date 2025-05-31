using Gameplay.Services.StaticData;
using UnityEngine;
using Zenject;

namespace UI.Windows.Factory
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IInstantiator _instantiator;
        
        private RectTransform _uiRoot;

        public WindowFactory(IStaticDataService staticData, IInstantiator instantiator)
        {
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public void SetUIRoot(RectTransform uiRoot) =>
            _uiRoot = uiRoot;

        public WindowBase CreateWindow(WindowType type)
        {
            WindowBase window = _instantiator.InstantiatePrefabForComponent<WindowBase>(PrefabFor(type), _uiRoot);
            window.SetId(type);
            
            return window;
        }

        private WindowBase PrefabFor(WindowType type) =>
            _staticData.WindowData.GetWindowByType(type).Prefab;
    }
}