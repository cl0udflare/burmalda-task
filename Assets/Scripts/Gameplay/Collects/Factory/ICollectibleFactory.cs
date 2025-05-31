using UnityEngine;

namespace Gameplay.Collects.Factory
{
    public interface ICollectibleFactory
    {
        Collectible CreateCollectible(CollectibleType type, Vector3 at);
    }
}