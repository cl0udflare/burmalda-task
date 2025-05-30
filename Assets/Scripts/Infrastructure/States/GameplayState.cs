using Gameplay.Factories.Curtain;
using Gameplay.Player;
using Gameplay.Player.Factory;
using Infrastructure.Services.Loading;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;
        private readonly IPlayerFactory _playerFactory;

        public GameplayState(ISceneLoader sceneLoader, ICurtainFactory curtainFactory, IPlayerFactory playerFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
            _playerFactory = playerFactory;
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
            CreatePlayer();
            
            _curtainFactory.Curtain.Hide();
        }

        private void CreatePlayer()
        {
            PlayerController player = _playerFactory.CreatePlayer();
            player.Run();
        }
    }
}