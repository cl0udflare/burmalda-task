using UnityEngine;

namespace Gameplay.Collects
{
    public class CollectibleSpawnMarker : MonoBehaviour
    {
        [SerializeField] private CollectibleType _type;

        public CollectibleType Type => _type;
    }
}