using Gameplay.Player.Configs;
using Gameplay.Player.Movement;
using Gameplay.Services.Cameras;
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
        [SerializeField] private HeroAnimator _animator;
        
        private GameStateMachine _stateMachine;
        private ICameraProvider _cameraProvider;

        private void OnValidate()
        {
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
            SetupCamera();
            SubscribeToMovementEvents();
        }

        public void SetConfig(PlayerConfig config) => 
            _movement.SetData(config.Stats, config.LaneOffset);

        public void Run() => 
            _movement.StartMove();

        public void Stop() => 
            _movement.StopMove();
        
        public void Kill()
        {
            Stop();
            _stateMachine.Enter<GameOverState>();
            Destroy(gameObject);
        }
        
        private void SetupCamera() => 
            _cameraProvider.Cinemachine.Follow = transform;
        
        private void SubscribeToMovementEvents()
        {
            _movement.OnJump += _animator.PlayJump;
            _movement.OnStrafeLeft += _animator.PlayStrafeLeft;
            _movement.OnStrafeRight += _animator.PlayStrafeRight;
        }

        private void UnsubscribeFromMovementEvents()
        {
            _movement.OnJump -= _animator.PlayJump;
            _movement.OnStrafeLeft -= _animator.PlayStrafeLeft;
            _movement.OnStrafeRight -= _animator.PlayStrafeRight;
        }

        private void OnDestroy()
        {
            UnsubscribeFromMovementEvents();
        }
    }
}