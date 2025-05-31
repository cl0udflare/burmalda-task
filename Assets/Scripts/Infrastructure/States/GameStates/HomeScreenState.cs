using Gameplay.Curtain.Factory.Curtain;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States.GameStates
{
    public class HomeScreenState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;

        public HomeScreenState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
        }
        
        public void Enter()
        {
            _curtainFactory.Curtain.Show();
            _sceneLoader.LoadScene(Scenes.HomeScreen, LoadedScene);
        }

        public void Exit()
        {
        }

        private void LoadedScene()
        {
            _curtainFactory.Curtain.Hide();
        }
    }
}