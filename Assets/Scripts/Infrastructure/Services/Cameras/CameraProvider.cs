using UnityEngine;

namespace Infrastructure.Services.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        public Camera MainCamera { get; private set; }

        public void SetMainCamera(Camera camera) => 
            MainCamera = camera;
    }
}