using Gameplay.Collects;
using UnityEngine;

namespace Gameplay.Levels.Markers
{
    public class CollectibleSpawnMarker : MonoBehaviour
    {
        [SerializeField] private CollectibleType _type;

        public CollectibleType Type
        {
            get => _type;
            set => _type = value;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.25f);
        }
    }
}