using Gameplay.Player.Configs;
using Infrastructure.Services.Cameras;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private HeroAnimator _animator;
        
        private GameStateMachine _stateMachine;
        private ICameraProvider _cameraProvider;

        private void OnValidate()
        {
            _characterController = GetComponent<CharacterController>();
            _movement = GetComponent<PlayerMovement>();
            _animator = GetComponentInChildren<HeroAnimator>();
        }

        [Inject]
        private void Construct(GameStateMachine stateMachine, ICameraProvider cameraProvider)
        {
            _stateMachine = stateMachine;
            _cameraProvider = cameraProvider;
        }

        private void Start()
        {
            _movement.Init(_characterController);
            _animator.Init(_characterController);
            
            _cameraProvider.Cinemachine.Follow = transform;
            
            _movement.OnJump += _animator.PlayJump;
            _movement.OnStrafeLeft += _animator.PlayStrafeLeft;
            _movement.OnStrafeRight += _animator.PlayStrafeRight;
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
            _movement.OnStrafeLeft -= _animator.PlayStrafeLeft;
            _movement.OnStrafeRight -= _animator.PlayStrafeRight;
        }

        private void OnDestroy()
        {
            Cleanup();
            
            _stateMachine.Enter<GameOverState>();
        }
    }
}