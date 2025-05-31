using System;
using System.Collections.Generic;
using Extentions;
using Gameplay.Collects.Factory;
using Gameplay.Levels;
using Gameplay.Services.Economy;

namespace Gameplay.Collects
{
    public class CollectibleManager
    {
        private readonly ICollectibleFactory _collectibleFactory;
        private readonly IEconomyService _economyService;

        private readonly List<Collectible> _collectibles = new();
        
        public CollectibleManager(ICollectibleFactory collectibleFactory, IEconomyService economyService)
        {
            _collectibleFactory = collectibleFactory;
            _economyService = economyService;
        }

        public void Init(List<CollectibleSpawnData> spawnData)
        {
            foreach (CollectibleSpawnData data in spawnData)
            {
                Collectible collectible = _collectibleFactory.CreateCollectible(data.Type, data.Position);
                if (!collectible) continue;
                
                collectible.OnCollected += Collect;
                _collectibles.Add(collectible);
            }
        }

        public void Cleanup()
        {
            foreach (Collectible collectible in _collectibles.NoNulls()) 
                CleanupCollectible(collectible);
            
            _collectibles.Clear();
        }

        private void Collect(Collectible collectible)
        {
            CleanupCollectible(collectible);

            switch (collectible.Type)
            {
                case CollectibleType.Unknown:
                    break;
                case CollectibleType.Coin:
                    CollectCoin(collectible.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CollectCoin(int value)
        {
            bool a = _economyService.IncreaseCurrency(value);
            if (a == false)
            {
                
            }
        }

        private void CleanupCollectible(Collectible collectible)
        {
            collectible.OnCollected -= Collect;
            collectible.DestroyCollectible();
        }
    }
}