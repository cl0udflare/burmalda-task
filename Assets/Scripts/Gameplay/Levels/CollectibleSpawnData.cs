using System;
using Gameplay.Collects;
using UnityEngine;

namespace Gameplay.Levels
{
    [Serializable]
    public class CollectibleSpawnData
    {
        public CollectibleType Type;
        public Vector3 Position;
    }
}