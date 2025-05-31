using Gameplay.Player.Configs;
using Gameplay.Services.StaticData;
using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticData;

        public PlayerFactory(DiContainer container, IStaticDataService staticData)
        {
            _container = container;
            _staticData = staticData;
        }

        public PlayerController CreatePlayer(Vector3 at)
        {
            PlayerConfig config = _staticData.PlayerConfig;
            
            PlayerController instantiate = Object.Instantiate(config.Prefab, at, Quaternion.identity);
            instantiate.SetConfig(config);
            
            _container.InjectGameObject(instantiate.gameObject);
            
            return instantiate;
        }
    }
}