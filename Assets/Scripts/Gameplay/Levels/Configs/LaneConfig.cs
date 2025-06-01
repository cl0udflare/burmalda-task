using UnityEngine;

namespace Gameplay.Levels.Configs
{
    [CreateAssetMenu(fileName = "LaneConfig", menuName = "Runner/Level Line")]
    public class LaneConfig : ScriptableObject
    {
        public float LaneOffset = 4f;

        public Vector3 GetWorldPosition(LevelLane lane, float z) => 
            new((int)lane * LaneOffset, 0f, z);
    }
}