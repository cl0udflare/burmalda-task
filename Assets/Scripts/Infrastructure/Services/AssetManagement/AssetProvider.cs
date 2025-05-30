using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : Object => 
            Resources.Load<T>(path);
    }
}