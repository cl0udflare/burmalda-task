using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
    }
}