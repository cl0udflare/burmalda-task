using System;
using Gameplay.Player.Configs;
using Gameplay.Services.Input;
using Gameplay.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float GRAVITY = -9.81f;
        private const float STICK_TO_GROUND_FORCE = -2f;
        
        [SerializeField] private CharacterController _controller;
        
        private IInputService _input;
        private PlayerStats _stats;
        private Vector3 _velocity;
        private int _currentLane;
        private float _lineOffset;
        private float _accelerationTimer;
        private bool _canMove;
        
        public event Action OnJump;
        public event Action OnStrafeLeft;
        public event Action OnStrafeRight;

        [Inject]
        private void Construct(IStaticDataService staticData, IInputService input) => 
            _input = input;

        private void Update()
        {
            if (!_canMove) return;
            
            HandleLaneChange();
            MoveForward();
            ApplyGravityAndJump();
            
            _controller.Move(_velocity * Time.deltaTime);
        }

        public void Init(CharacterController characterController) => 
            _controller = characterController;

        public void SetData(PlayerStats stats, float lineOffset)
        {
            stats.MovementSpeed = 0;
            _stats = stats;
            _lineOffset = lineOffset;
        }
        
        public void StartMove() => 
            _canMove = true;

        public void StopMove() => 
            _canMove = false;

        private void HandleLaneChange()
        {
            int direction = 0;
            if (_input.Left)
            {
                direction = -1;
                OnStrafeLeft?.Invoke();
            }

            if (_input.Right)
            {
                direction = 1;
                OnStrafeRight?.Invoke();
            }

            if (direction != 0) 
                _currentLane = Mathf.Clamp(_currentLane + direction, -1, 1);

            float targetX = _currentLane * _lineOffset;
            float currentX = transform.position.x;
            float deltaX = targetX - currentX;
            _velocity.x = deltaX * _stats.StrafeSpeed;
        }
        
        private void MoveForward()
        {
            _accelerationTimer += Time.deltaTime;
            float time = Mathf.Clamp01(_accelerationTimer / _stats.AccelerationTime);
            float speedFactor = _stats.AccelerationCurve.Evaluate(time);
            _velocity.z = _stats.MovementSpeed * speedFactor;
        }

        private void ApplyGravityAndJump()
        {
            bool isGrounded = _controller.isGrounded;
            
            if (isGrounded && _velocity.y <= 0) 
                _velocity.y = STICK_TO_GROUND_FORCE;

            if (isGrounded && _input.Jump)
            {
                // _velocity.y = Mathf.Sqrt(-2f * GRAVITY * _stats.JumpForce);
                OnJump?.Invoke();
            }

            _velocity.y += GRAVITY * Time.deltaTime;
        }
    }
}