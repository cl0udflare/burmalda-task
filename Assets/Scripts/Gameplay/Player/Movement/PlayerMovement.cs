using System;
using Gameplay.Player.Configs;
using Gameplay.Services.Input;
using Gameplay.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        
        private IInputService _input;
        private PlayerStats _stats;
        private MovementEngine _movementEngine;
        private Vector3 _velocity;
        private int _currentLane;
        private float _lineOffset;
        private float _accelerationTimer;
        private bool _canMove;

        public event Action OnJump;
        public event Action OnStrafeLeft;
        public event Action OnStrafeRight;

        private void OnValidate() => 
            _controller = GetComponent<CharacterController>();

        [Inject]
        private void Construct(IStaticDataService staticData, IInputService input) => 
            _input = input;

        private void Update()
        {
            if (!_canMove) return;

            int strafe = GetStrafeDirection();
            bool jump = _input.Jump;

            if (strafe == -1) OnStrafeLeft?.Invoke();
            if (strafe == 1) OnStrafeRight?.Invoke();
            if (jump) OnJump?.Invoke();

            _movementEngine.Tick(strafe, jump, transform);
        }

        public void SetData(PlayerStats stats, float lineOffset) => 
            _movementEngine = new MovementEngine(_controller, stats, lineOffset);

        public void StartMove() => _canMove = true;

        public void StopMove() => _canMove = false;

        private int GetStrafeDirection() => 
            _input.Left ? -1 : _input.Right ? 1 : 0;
    }
}