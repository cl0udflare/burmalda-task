using UnityEngine;

namespace Gameplay.Player
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Jump = Animator.StringToHash("Jump");

        [SerializeField] private Animator _animator;
        
        private CharacterController _controller;

        private void OnValidate()
        {
            if (!_animator) _animator = GetComponentInChildren<Animator>();
        }

        private void Update() => Move();

        public void Init(CharacterController characterController) => 
            _controller = characterController;

        public void PlayJump() => _animator.SetTrigger(Jump);
       
        public void PlayDeath() => _animator.SetTrigger(Die);
        
        public void StopMoving() => _animator.SetBool(IsMoving, false);

        private void Move()
        {
            if (!_controller) return;
            
            float speed = _controller.velocity.magnitude;
            
            if (speed > 0)
            {
                _animator.SetBool(IsMoving, true);
                _animator.SetFloat(Speed, speed, 0.1f, Time.deltaTime);
            }
            else
            {
                _animator.SetBool(IsMoving, false);  
            }
        }
    }
}