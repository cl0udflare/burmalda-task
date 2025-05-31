using Gameplay.Services.StaticData;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.LoadAll();
            
            _sceneLoader.LoadScene(Scenes.Boot, LoadedScene);
        }

        public void Exit()
        {
        }
        
        private void LoadedScene() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}