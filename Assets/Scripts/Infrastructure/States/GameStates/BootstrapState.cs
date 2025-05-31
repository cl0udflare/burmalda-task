using Gameplay.Services.StaticData;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;
using Progress.Data;
using Progress.Services.Provider;

namespace Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressProvider _progressProvider;

        public BootstrapState(
            GameStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            IStaticDataService staticDataService,
            IProgressProvider progressProvider)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            _staticDataService.LoadAll();
            _progressProvider.SetEconomyData(new EconomyData());
            
            _sceneLoader.LoadScene(Scenes.Boot, LoadedScene);
        }

        public void Exit()
        {
        }
        
        private void LoadedScene() => 
            _stateMachine.Enter<HomeScreenState>();
    }
}