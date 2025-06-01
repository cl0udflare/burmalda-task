using Gameplay.Player.Configs;
using UnityEngine;

namespace Gameplay.Player.Movement
{
    public class MovementEngine
    {
        private readonly CharacterController _controller;
        private readonly PlayerStats _stats;
        private readonly float _laneOffset;
        private Vector3 _velocity;
        private int _currentLane;
        private float _accelerationTimer;

        public MovementEngine(CharacterController controller, PlayerStats stats, float laneOffset)
        {
            _controller = controller;
            _stats = stats;
            _laneOffset = laneOffset;
        }

        public Vector3 Tick(int strafeInput, bool jumpInput, Transform mover)
        {
            HandleLaneChange(strafeInput, mover);
            ApplyForwardAcceleration();
            ApplyGravityAndJump(jumpInput);

            _controller.Move(_velocity * Time.deltaTime);
            return _velocity;
        }

        private void HandleLaneChange(int direction, Transform mover)
        {
            if (direction != 0)
                _currentLane = Mathf.Clamp(_currentLane + direction, -1, 1);

            float targetX = _currentLane * _laneOffset;
            float currentX = mover.position.x;
            float deltaX = targetX - currentX;
            _velocity.x = deltaX * _stats.StrafeSpeed;
        }

        private void ApplyForwardAcceleration()
        {
            _accelerationTimer += Time.deltaTime;
            float time = Mathf.Clamp01(_accelerationTimer / _stats.AccelerationTime);
            _velocity.z = _stats.MovementSpeed * _stats.AccelerationCurve.Evaluate(time);
        }

        private void ApplyGravityAndJump(bool jumpInput)
        {
            const float GRAVITY = -9.81f;
            const float STICK_TO_GROUND_FORCE = -2f;

            bool isGrounded = _controller.isGrounded;

            if (isGrounded && _velocity.y <= 0)
                _velocity.y = STICK_TO_GROUND_FORCE;

            if (isGrounded && jumpInput)
                _velocity.y = Mathf.Sqrt(-2f * GRAVITY * _stats.JumpForce);

            _velocity.y += GRAVITY * Time.deltaTime;
        }
    }
}