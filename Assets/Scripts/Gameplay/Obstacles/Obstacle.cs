using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider trigger)
        {
            if (trigger.TryGetComponent(out PlayerController player))
            {
                Destroy(player.gameObject);
            }
        }
    }
}