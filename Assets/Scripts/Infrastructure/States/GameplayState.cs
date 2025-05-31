using System.Collections.Generic;
using System.Linq;
using Gameplay.Collects;
using Gameplay.Curtain.Factory.Curtain;
using Gameplay.Levels;
using Gameplay.Player;
using Gameplay.Player.Factory;
using Gameplay.Services.StaticData;
using Infrastructure.Loading;
using Infrastructure.States.Interfaces;
using Infrastructure.Systems;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameplayState : IState //TODO: GameManager
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ICurtainFactory _curtainFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly IStaticDataService _staticData;
        private readonly ISystemFactory _systemFactory;

        public GameplayState(
            ISceneLoader sceneLoader, 
            ICurtainFactory curtainFactory, 
            IPlayerFactory playerFactory,
            IStaticDataService staticData,
            ISystemFactory systemFactory)
        {
            _sceneLoader = sceneLoader;
            _curtainFactory = curtainFactory;
            _playerFactory = playerFactory;
            _staticData = staticData;
            _systemFactory = systemFactory;
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
            InitLevel();
            _curtainFactory.Curtain.Hide();
        }

        private void InitLevel()
        {
            LevelTransferConfig config = _staticData.Levels.First().Value;
            
            CreateCollectables(config.Collectibles);
            CreatePlayer(config.PlayerSpawn.Position);
        }

        private void CreateCollectables(List<CollectibleSpawnData> spawnData)
        {
            CollectibleManager manager = _systemFactory.Create<CollectibleManager>();
            manager.Init(spawnData);
        }

        private void CreatePlayer(Vector3 spawnPosition)
        {
            PlayerController player = _playerFactory.CreatePlayer(spawnPosition);
            player.Run();
        }
    }
}