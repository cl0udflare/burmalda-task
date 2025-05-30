using System;
using UnityEngine;

namespace Gameplay.Player.Configs
{
    [Serializable]
    public class PlayerStats
    {
        public float MovementSpeed = 5f;
        public float StrafeSpeed = 3.5f;
        public float JumpForce = 4f;
        [Header("Acceleration")]
        public AnimationCurve AccelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public float AccelerationTime = 2f;
    }
}