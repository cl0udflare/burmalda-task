using UnityEngine;

namespace UI.Logic.Buttons
{
    public class ExitButton : ButtonBase
    {
        private void Start() => 
            RegisterCallback(Exit);

        private void Exit() => 
            Application.Quit();
    }
}