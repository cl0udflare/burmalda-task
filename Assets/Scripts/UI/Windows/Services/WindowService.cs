using System.Collections.Generic;
using UI.Windows.Factory;
using UnityEngine;

namespace UI.Windows.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowFactory _windowFactory;

        private readonly List<WindowBase> _openedWindows = new();

        public WindowService(IWindowFactory windowFactory) =>
            _windowFactory = windowFactory;

        public void Open(WindowType windowId) => 
            _openedWindows.Add(_windowFactory.CreateWindow(windowId));

        public void Close(WindowType windowId)
        {
            WindowBase window = _openedWindows.Find(x => x.Id == windowId);
            _openedWindows.Remove(window);
      
            Object.Destroy(window.gameObject);
        }
    }
}