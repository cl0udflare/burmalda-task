using Infrastructure.States.Interfaces;
using Progress.Data;
using Progress.Provider;

namespace Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressProvider _progressProvider;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressProvider progressProvider)
        {
            _gameStateMachine = gameStateMachine;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<HomeScreenState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            ProgressData progress = new ProgressData();
            _progressProvider.SetProgressData(progress);
        }
    }
}