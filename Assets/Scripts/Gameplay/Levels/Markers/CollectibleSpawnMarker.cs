using Gameplay.Collects;
using UnityEngine;

namespace Gameplay.Levels.Markers
{
    public class CollectibleSpawnMarker : MonoBehaviour
    {
        [SerializeField] private CollectibleType _type;

        public CollectibleType Type => _type;
    }
}