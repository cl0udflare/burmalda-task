using System;
using Infrastructure;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace UI.Buttons
{
    public class StateChangerButton : ButtonBase
    {
        [SerializeField] private StateType _stateType = StateType.Unknown;
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        private void Start() =>
            RegisterCallback(MoveToGameplayState);

        private void OnDestroy() =>
            CleanupCallback();

        private void MoveToGameplayState()
        {
            switch (_stateType)
            {
                case StateType.Unknown:
                    break;
                case StateType.Gameplay:
                    _stateMachine.Enter<GameplayState>();
                    break;
                case StateType.HomeScreen:
                    _stateMachine.Enter<HomeScreenState>();
                    break;
                case StateType.GameOver:
                    _stateMachine.Enter<GameOverState>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}