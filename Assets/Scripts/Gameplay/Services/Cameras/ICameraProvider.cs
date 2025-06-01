using Unity.Cinemachine;
using UnityEngine;

namespace Gameplay.Services.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        CinemachineCamera Cinemachine { get; }
        void SetMainCamera(Camera camera);
        void SetCinemachineCamera(CinemachineCamera cinemachine);
    }
}