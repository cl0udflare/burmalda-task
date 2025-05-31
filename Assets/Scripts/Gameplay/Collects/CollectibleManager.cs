using System.Collections.Generic;
using Extentions;
using Gameplay.Collects.Factory;
using Gameplay.Levels;

namespace Gameplay.Collects
{
    public class CollectibleManager
    {
        private readonly ICollectibleFactory _collectibleFactory;

        private readonly List<Collectible> _collectibles = new();
        
        public CollectibleManager(ICollectibleFactory collectibleFactory)
        {
            _collectibleFactory = collectibleFactory;
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
        }

        private void CleanupCollectible(Collectible collectible)
        {
            collectible.OnCollected -= Collect;
            collectible.DestroyCollectible();
        }
    }
}