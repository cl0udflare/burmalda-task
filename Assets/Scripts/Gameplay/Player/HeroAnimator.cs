using System;
using Gameplay.Animations;
using UnityEngine;

namespace Gameplay.Player
{
    public class HeroAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int StrafeLeft = Animator.StringToHash("Left");
        private static readonly int StrafeRight = Animator.StringToHash("Right");
        
        private readonly int _movementStateHash = Animator.StringToHash("Movement");
        private readonly int _runningRightStateHash = Animator.StringToHash("RunningRight");
        private readonly int _runningLeftStateHash = Animator.StringToHash("RunningLeft");
        private readonly int _jumpStateHash = Animator.StringToHash("Jump");

        [SerializeField] private Animator _animator;
        
        private CharacterController _controller;
        private IAnimationStateReader _animationStateReaderImplementation;

        public AnimatorState State { get; private set; }
        
        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;
        
        private void OnValidate()
        {
            if (!_animator) _animator = GetComponentInChildren<Animator>();
        }

        private void Update() => Move();

        public void Init(CharacterController characterController) => 
            _controller = characterController;

        public void PlayJump() => _animator.SetTrigger(Jump);
        
        public void PlayStrafeLeft()
        {
            if (State == AnimatorState.Jump) 
                return;
            
            _animator.SetTrigger(StrafeLeft);
        }

        public void PlayStrafeRight()
        {
            if (State == AnimatorState.Jump) 
                return;
            
            _animator.SetTrigger(StrafeRight);
        }

        private void Move()
        {
            if (!_controller) return;
            
            float speed = _controller.velocity.magnitude;
            _animator.SetFloat(Speed, speed, 0.1f, Time.deltaTime);
        }

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) => 
            StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            
            if (stateHash == _movementStateHash)
                state = AnimatorState.Move;
            else if (stateHash == _runningLeftStateHash)
                state = AnimatorState.MoveLeft;
            else if (stateHash == _runningRightStateHash)
                state = AnimatorState.MoveRight;
            else if (stateHash == _jumpStateHash)
                state = AnimatorState.Jump;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}