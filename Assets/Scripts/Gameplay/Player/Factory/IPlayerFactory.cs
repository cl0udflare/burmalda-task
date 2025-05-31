using UnityEngine;

namespace Gameplay.Player.Factory
{
    public interface IPlayerFactory
    {
        PlayerController CreatePlayer(Vector3 at);
    }
}