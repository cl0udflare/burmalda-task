using UnityEngine;

namespace UI.ButtonsLogic
{
    public class ExitButton : ButtonBase
    {
        private void Start() => 
            RegisterCallback(Exit);

        private void Exit() => 
            Application.Quit();
    }
}