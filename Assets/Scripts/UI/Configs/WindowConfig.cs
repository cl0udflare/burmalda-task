using System;
using UI.Services.Window;
using UI.Windows;

namespace UI.Configs
{
    [Serializable]
    public class WindowSetup
    {
        public WindowType WindowType;
        public WindowBase Prefab;
    }
}