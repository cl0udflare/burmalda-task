using DG.Tweening;
using UnityEngine;

namespace Logic.Curtain
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingCurtain : MonoBehaviour
    {
        private const float FADE_TARGET_ALPHA = 0f;
        private const float FADE_DURATION = 0.2f;
        private const float FADE_DELAY = 0.5f;

        [SerializeField] private CanvasGroup _canvasGroup;

        private void OnValidate() => 
            _canvasGroup = GetComponent<CanvasGroup>();

        public void Show()
        {
            ReturnToOriginalValues();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _canvasGroup.DOFade(FADE_TARGET_ALPHA, FADE_DURATION)
                .SetEase(Ease.OutBounce)
                .SetDelay(FADE_DELAY)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
        }

        private void ReturnToOriginalValues() => 
            _canvasGroup.alpha = 1;
    }
}