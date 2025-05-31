using UnityEngine;

namespace UI.Windows.Factory
{
    public interface IWindowFactory
    {
        void SetUIRoot(RectTransform uiRoot);
        WindowBase CreateWindow(WindowType type);
    }
}