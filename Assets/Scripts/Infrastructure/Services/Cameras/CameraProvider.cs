using Unity.Cinemachine;
using UnityEngine;

namespace Infrastructure.Services.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        public Camera MainCamera { get; private set; }
        public CinemachineCamera Cinemachine { get; private set; }

        public void SetMainCamera(Camera camera) => 
            MainCamera = camera;

        public void SetCinemachineCamera(CinemachineCamera cinemachine) => 
            Cinemachine = cinemachine;
    }
}