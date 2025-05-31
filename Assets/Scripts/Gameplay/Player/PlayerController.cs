using Gameplay.Player.Configs;
using UnityEngine;

namespace Gameplay.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;

        private void OnValidate()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        public void SetConfig(PlayerConfig config)
        {
            _movement.Init(config.Stats, config.LaneOffset);
        }

        public void Run() => _movement.StartMove();

        public void Stop() => _movement.StopMove();
    }
}