using UI.Factory;
using UnityEngine;

namespace UI.Windows.Services
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        private WindowBase _currentWindow;
        
        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowType windowType)
        {
            DestroyCurrentWindow();
            
            switch (windowType)
            {
             
            }
        }

        private void DestroyCurrentWindow()
        {
            if (_currentWindow)
                Object.Destroy(_currentWindow.gameObject);
        }
    }
}