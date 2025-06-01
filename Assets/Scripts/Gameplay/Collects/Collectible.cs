using System;
using Gameplay.Animations.DoAnimations;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Collects
{
    [RequireComponent(typeof(DoCollect))]
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private DoCollect _collectAnimation;
        
        private CollectibleType _type;
        private int _value;

        public CollectibleType Type => _type;
        public int Value => _value;
        
        public event Action<Collectible> OnCollected;

        private void OnValidate()
        {
            if(!_triggerObserver) _triggerObserver = GetComponentInChildren<TriggerObserver>();
            if(!_collectAnimation) _collectAnimation = GetComponentInChildren<DoCollect>();
        }
        
        public void SetData(CollectibleType type, int value)
        {
            _type = type;
            _value = value;
        }

        public void Init() => 
            _triggerObserver.TriggerEnter += TriggerEnter;

        public void DestroyCollectible()
        {
            _collectAnimation.Play(() =>
            {
                Destroy(gameObject);
            });
        }

        private void TriggerEnter(Collider trigger)
        {
            if (trigger.TryGetComponent(out PlayerController player)) 
                OnCollected?.Invoke(this);
        }

        private void OnDestroy() => 
            _triggerObserver.TriggerEnter -= TriggerEnter;
    }
}