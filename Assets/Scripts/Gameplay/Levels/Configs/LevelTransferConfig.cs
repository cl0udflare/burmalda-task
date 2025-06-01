using System;
using System.Collections.Generic;
using Gameplay.Collects;
using UnityEngine;

namespace Gameplay.Levels.Configs
{
    [CreateAssetMenu(fileName = "LevelTransferConfig", menuName = "Runner/Level Transfer")]
    public class LevelTransferConfig : ScriptableObject
    {
        public string LevelName;
        [Space]
        public PlayerSpawnData PlayerSpawn;
        public List<CollectibleSpawnData> Collectibles = new();
    }
    
    [Serializable]
    public class PlayerSpawnData
    {
        public Vector3 Position;
    }
    
    [Serializable]
    public class CollectibleSpawnData
    {
        public CollectibleType Type;
        public Vector3 Position;
    }
}