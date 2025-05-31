using Gameplay.Player.Configs;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerMovement), typeof(HeroAnimator))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private HeroAnimator _animator;
        
        private GameStateMachine _stateMachine;

        private void OnValidate()
        {
            _characterController = GetComponent<CharacterController>();
            _movement = GetComponent<PlayerMovement>();
            _animator = GetComponent<HeroAnimator>();
        }

        [Inject]
        private void Construct(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start()
        {
            _movement.Init(_characterController);
            _animator.Init(_characterController);
            
            _movement.OnJump += _animator.PlayJump;
        }

        public void SetConfig(PlayerConfig config)
        {
            _movement.SetData(config.Stats, config.LaneOffset);
        }

        public void Run() => _movement.StartMove();

        public void Stop() => _movement.StopMove();

        private void Cleanup()
        {
            _movement.OnJump -= _animator.PlayJump;
        }

        private void OnDestroy()
        {
            Cleanup();
            
            _stateMachine.Enter<GameOverState>();
        }
    }
}