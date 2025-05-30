using Gameplay.Factories.Curtain;
using Infrastructure.Services.Loading;
using Infrastructure.States.Interfaces;
using UI.Factories;

namespace Infrastructure.States
{
    public class HomeScreenState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;
        private readonly IUIFactory _uiFactory;

        public HomeScreenState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
            _uiFactory = uiFactory;
        }
        
        public void Enter()
        {
            _curtainFactory.Curtain.Show();
            _sceneLoader.LoadScene(Scenes.HomeScreen, LoadedScene);
        }

        public void Exit()
        {
            _uiFactory.Cleanup();
        }

        private void LoadedScene()
        {
            CreateUI();
            
            _curtainFactory.Curtain.Hide();
        }

        private void CreateUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateMainMenu();
        }
    }
}