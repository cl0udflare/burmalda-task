using UnityEngine;

namespace UI.Buttons
{
    public class ExitButton : ButtonBase
    {
        private void Start() => 
            RegisterCallback(Exit);

        private void OnDestroy() => 
            CleanupCallback();

        private void Exit() => 
            Application.Quit();
    }
}