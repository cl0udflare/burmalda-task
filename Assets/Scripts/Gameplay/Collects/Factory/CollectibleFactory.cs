using Gameplay.Collects.Configs;
using Gameplay.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Gameplay.Collects.Factory
{
    public class CollectibleFactory : ICollectibleFactory
    {
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticData;

        public CollectibleFactory(DiContainer container, IStaticDataService staticData)
        {
            _container = container;
            _staticData = staticData;
        }

        public Collectible CreateCollectible(CollectibleType type, Vector3 at)
        {
            bool isGetValue = _staticData.Collectibles.TryGetValue(type, out CollectibleConfig config);

            if (isGetValue)
            {
                Collectible collectible = Object.Instantiate(config.Prefab, at, Quaternion.identity);
                collectible.SetData(config.Type, config.Value);
                collectible.Init();
                
                _container.InjectGameObject(collectible.gameObject);
            }

            return null;
        }
    }
}