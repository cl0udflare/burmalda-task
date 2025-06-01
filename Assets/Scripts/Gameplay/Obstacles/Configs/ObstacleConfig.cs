using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Obstacles.Configs
{
    [CreateAssetMenu(fileName = "ObstaclesConfig", menuName = "Runner/Obstacles")]
    public class ObstacleConfig : ScriptableObject
    {
        public List<Obstacle> Obstacles = new();
        
        public Obstacle GetPrefab(ObstacleType type)
        {
            foreach (var entry in Obstacles.Where(entry => entry.Type == type))
                return entry;
            
            Debug.LogWarning($"No prefab found for ObstacleType: {type}");
            return null;
        }
    }
}