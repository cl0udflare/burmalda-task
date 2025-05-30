using Gameplay.Factories.Curtain;
using Infrastructure.Services.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;

        public GameplayState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
        }
        
        public void Enter()
        {
            _curtainFactory.Curtain.Show();
            _sceneLoader.LoadScene(Scenes.Gameplay, LoadedScene);
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