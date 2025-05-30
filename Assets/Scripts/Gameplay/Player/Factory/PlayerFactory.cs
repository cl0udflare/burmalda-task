using Gameplay.Player.Configs;
using Gameplay.Services.StaticData;
using Infrastructure.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private const string PLAYER_PATH = "Gameplay/Player";

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        public PlayerFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public PlayerController CreatePlayer()
        {
            PlayerConfig config = _staticData.PlayerConfig;
            PlayerController player = _assetProvider.Load<PlayerController>(PLAYER_PATH);
            
            PlayerController instantiate = Object.Instantiate(player);
            instantiate.SetConfig(config);
            
            _container.InjectGameObject(instantiate.gameObject);
            
            return instantiate;
        }
    }
}