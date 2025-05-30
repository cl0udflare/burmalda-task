using Gameplay.Factories.Curtain;
using Infrastructure.Services.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class HomeScreenState : IPayloadedState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;

        public HomeScreenState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
        }
        
        public void Enter(string sceneName)
        {
            _curtainFactory.Curtain.Show();
            _sceneLoader.LoadScene(sceneName, LoadedScene);
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