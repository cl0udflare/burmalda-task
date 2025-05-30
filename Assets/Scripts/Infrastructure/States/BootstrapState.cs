using Infrastructure.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(Scenes.Boot, LoadedScene);
        }

        public void Exit()
        {
        }
        
        private void LoadedScene() =>
            _stateMachine.Enter<HomeScreenState, string>(Scenes.HomeScreen);
    }
}