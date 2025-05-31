using Infrastructure;
using Infrastructure.States;
using Zenject;

namespace UI.Logic.Buttons
{
    public class StartButton : ButtonBase
    {
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start() => 
            RegisterCallback(MoveToGameplayState);

        private void MoveToGameplayState() => 
            _stateMachine.Enter<GameplayState>();
    }
}