using UnityEngine;

namespace Infrastructure.Services.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
    }
}