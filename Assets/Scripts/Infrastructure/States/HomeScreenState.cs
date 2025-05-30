using Infrastructure.Factories.Curtain;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class HomeScreenState : IPayloadedState<string>
    {
        private const string LOADING_STATUS_TEXT = "Loading and instantiating home screen...";
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;

        public HomeScreenState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
        }
        
        public void Enter(string sceneName)
        {
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