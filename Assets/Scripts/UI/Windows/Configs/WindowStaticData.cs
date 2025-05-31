using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Windows.Configs
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "Runner/Windows")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowSetup> Windows;

        public WindowSetup GetWindowByType(WindowType type) => 
            Windows.FirstOrDefault(x => x.WindowType == type);
    }
}