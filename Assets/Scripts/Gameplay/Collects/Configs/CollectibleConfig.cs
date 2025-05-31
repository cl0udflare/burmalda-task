using UnityEngine;

namespace Gameplay.Collects.Configs
{
    [CreateAssetMenu(fileName = "CollectibleConfig", menuName = "Runner/Collectible")]
    public class CollectibleConfig : ScriptableObject
    {
        public CollectibleType Type = CollectibleType.Unknown;
        public Collectible Prefab;
        public int Value = 1;
    }
}