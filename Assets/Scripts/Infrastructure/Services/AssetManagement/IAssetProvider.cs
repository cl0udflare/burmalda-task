using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
    }
}