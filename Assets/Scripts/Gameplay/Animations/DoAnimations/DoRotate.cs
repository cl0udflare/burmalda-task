using DG.Tweening;
using UnityEngine;

namespace Gameplay.Animations.DoAnimations
{
    public class DoRotate : MonoBehaviour
    {
        [Header("Rotation")]
        [SerializeField] private Vector3 _rotationAxis = Vector3.up;
        [SerializeField] private float _rotationSpeed = 90f;
        [SerializeField] private bool _loop = true;
        [Header("Settings")]
        [SerializeField] private bool _startOnAwake = true;

        private Tween _rotateTween;

        private void Start()
        {
            if (_startOnAwake)
                Play();
        }

        public void Play()
        {
            _rotateTween?.Kill();

            _rotateTween = transform
                .DORotate(_rotationAxis * 360f, 360f / _rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(_loop ? -1 : 1);
        }

        private void OnDestroy() => 
            _rotateTween?.Kill();
    }
}