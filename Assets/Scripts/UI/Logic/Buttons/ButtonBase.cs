using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Logic.Buttons
{
    public abstract class ButtonBase : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        private void OnValidate() => 
            _button = GetComponent<Button>();

        protected void RegisterCallback(Action callback) => 
            _button.onClick.AddListener(callback.Invoke);

        protected void CleanupCallback() => 
            _button.onClick.RemoveAllListeners();
    }
}