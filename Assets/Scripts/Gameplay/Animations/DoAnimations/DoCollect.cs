using DG.Tweening;
using UnityEngine;

namespace Gameplay.Animations.DoAnimations
{
    public class DoCollect : MonoBehaviour
    {
        [Header("Jump")]
        [SerializeField] private float _jumpPower = 1.5f;
        [SerializeField] private float _jumpDuration = 0.4f;
        [SerializeField] private int _jumpCount = 1;
        [Header("Fade")]
        [SerializeField] private float _fadeDuration = 0.2f;
        [SerializeField] private float _scaleDownDuration = 0.3f;
        [Header("Settings")]
        [SerializeField] private bool _startOnAwake = true;

        private void Start()
        {
            if (_startOnAwake)
                Play();
        }
        
        public void Play(System.Action onComplete = null)
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(transform
                .DOJump(transform.position, _jumpPower, _jumpCount, _jumpDuration)
                .SetEase(Ease.OutQuad));

            seq.Join(transform
                .DOScale(Vector3.zero, _scaleDownDuration)
                .SetEase(Ease.InBack)
                .SetDelay(_jumpDuration * 0.5f));

            seq.OnComplete(() =>
            {
                onComplete?.Invoke();
                Destroy(gameObject);
            });
        }
    }
}