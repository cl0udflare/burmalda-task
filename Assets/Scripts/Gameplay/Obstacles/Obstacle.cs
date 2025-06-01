using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        // [SerializeField] private TriggerObserver _triggerObserver;
        //
        // private void OnValidate()
        // {
        //     if (!_triggerObserver) 
        //         _triggerObserver = GetComponentInChildren<TriggerObserver>();
        // }
        //
        // private void Start() => 
        //     _triggerObserver.TriggerEnter += OnTriggered;
        //
        // private void OnDestroy() => 
        //     _triggerObserver.TriggerEnter -= OnTriggered;

        private void OnTriggerEnter(Collider trigger)
        {
            if (trigger.TryGetComponent(out PlayerController player))
            {
                Destroy(player.gameObject);
            }
        }
    }
}