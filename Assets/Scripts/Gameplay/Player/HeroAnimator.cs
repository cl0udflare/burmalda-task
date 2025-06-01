using System;
using Gameplay.Animations;
using UnityEngine;

namespace Gameplay.Player
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int StrafeLeft = Animator.StringToHash("Left");
        private static readonly int StrafeRight = Animator.StringToHash("Right");
        private static readonly int IsDeath = Animator.StringToHash("IdDeath");
        private static readonly int Die = Animator.StringToHash("Death");
        
        private readonly int _movementStateHash = Animator.StringToHash("Movement");
        private readonly int _runningRightStateHash = Animator.StringToHash("RunningRight");
        private readonly int _runningLeftStateHash = Animator.StringToHash("RunningLeft");
        private readonly int _jumpStateHash = Animator.StringToHash("Jump");
        private readonly int _dieStateHash = Animator.StringToHash("Death");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _controller;

        public AnimatorState State { get; private set; }
        
        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;
        
        private void OnValidate() => 
            _animator = GetComponent<Animator>();

        private void Update() => 
            Move();

        public void PlayJump() => 
            _animator.SetTrigger(Jump);

        public void PlayDeath()
        {
            _animator.SetBool(IsDeath, true);
            _animator.SetTrigger(Die);
        }

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
            else if (stateHash == _dieStateHash)
                state = AnimatorState.Die;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}