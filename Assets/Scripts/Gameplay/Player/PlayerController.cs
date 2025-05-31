using Gameplay.Player.Configs;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        
        private GameStateMachine _stateMachine;

        private void OnValidate()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        [Inject]
        private void Construct(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void SetConfig(PlayerConfig config)
        {
            _movement.Init(config.Stats, config.LaneOffset);
        }

        public void Run() => _movement.StartMove();

        public void Stop() => _movement.StopMove();

        private void OnDestroy()
        {
            _stateMachine.Enter<GameOverState>();
        }
    }
}