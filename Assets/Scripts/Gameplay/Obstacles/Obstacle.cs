using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private ObstacleType _type;
        [SerializeField] private TriggerObserver _triggerObserver;

        public ObstacleType Type => _type;

        private void OnValidate()
        {
            if(_triggerObserver) _triggerObserver = GetComponentInChildren<TriggerObserver>();
        }

        private void OnTriggerEnter(Collider trigger)
        {
            if (trigger.TryGetComponent(out PlayerController player)) 
                player.Kill();
        }
    }
}