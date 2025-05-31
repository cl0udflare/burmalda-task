﻿using UI.Windows.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class UIInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private RectTransform _uiRoot;
        
        private IWindowFactory _windowFactory;

        [Inject]
        private void Construct(IWindowFactory windowFactory) => 
            _windowFactory = windowFactory;
    
        public void Initialize() => 
            _windowFactory.SetUIRoot(_uiRoot);
    }
}