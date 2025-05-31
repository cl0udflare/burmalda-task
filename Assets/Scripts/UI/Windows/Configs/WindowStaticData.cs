using System.Collections.Generic;
using UnityEngine;

namespace UI.Windows.Configs
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "Runner/Windows")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowSetup> Windows;
    }
}