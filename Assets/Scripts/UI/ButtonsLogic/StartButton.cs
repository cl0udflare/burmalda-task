using Infrastructure.States;
using Zenject;

namespace UI.ButtonsLogic
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