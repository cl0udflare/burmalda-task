using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Collects;
using Gameplay.Obstacles;
using UnityEngine;

namespace Gameplay.Levels.Configs
{
    [CreateAssetMenu(fileName = "LevelConstructor", menuName = "Runner/Level Constructor")]
    public class LevelConstructor : ScriptableObject
    {
        public GameObject GroundPrefab;
        [Space] public List<GroundSegmentData> GroundSegments;

        public List<ObstacleType> GetAllObstacleTypes()
        {
            return (from segmentData in GroundSegments
                    from obstacleGroup in segmentData.Obstacles
                    select obstacleGroup.Type)
                .ToList();
        }

        public List<CollectibleType> GetACollectibleTypes()
        {
            return (from segmentData in GroundSegments
                    from collectibleGroup in segmentData.Coins
                    select collectibleGroup.Type)
                .ToList();
        }
    }

    [Serializable]
    public class GroundSegmentData
    {
        public List<ObstacleGroup> Obstacles = new();
        public List<CollectibleGroup> Coins = new();
    }

    [Serializable]
    public class ObstacleGroup
    {
        public ObstacleType Type;
        public LevelLane Lane;
        public float LocalZ;
    }

    [Serializable]
    public class CollectibleGroup
    {
        public CollectibleType Type;
        public LevelLane Lane;
        public float StartZ;
        public int Count = 5;
        public float StepZ = 2f;
    }
}