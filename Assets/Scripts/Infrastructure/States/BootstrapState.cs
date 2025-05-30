using Infrastructure.Factories.Curtain;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader, ICurtainFactory curtainFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
        }

        public void Enter()
        {
            _curtainFactory.Curtain.Show();
            _sceneLoader.LoadScene(Scenes.Boot, LoadedScene);
        }

        public void Exit()
        {
        }
        
        private void LoadedScene() =>
            _stateMachine.Enter<HomeScreenState, string>(Scenes.HomeScreen);
    }
}