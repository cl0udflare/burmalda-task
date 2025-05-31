using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Levels
{
    [CreateAssetMenu(fileName = "LevelTransferConfig", menuName = "Runner/Level Transfer")]
    public class LevelTransferConfig : ScriptableObject
    {
        public string LevelName;
        [Space]
        public PlayerSpawnData PlayerSpawn;
        public List<CollectibleSpawnData> Collectibles = new();
    }
}