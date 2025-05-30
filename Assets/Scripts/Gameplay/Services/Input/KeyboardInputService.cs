using UnityEngine;

namespace Gameplay.Services.Input
{
    public class KeyboardInputService : IInputService
    {
        public bool Jump => UnityEngine.Input.GetKeyDown(KeyCode.Space);
        public bool Left => UnityEngine.Input.GetKeyDown(KeyCode.A);
        public bool Right => UnityEngine.Input.GetKeyDown(KeyCode.D);
    }
}