using Gameplay.Player;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Gameplay.Levels
{
    public class LevelComplete : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player)) 
                _stateMachine.Enter<GameOverState>();
        }
    }
}