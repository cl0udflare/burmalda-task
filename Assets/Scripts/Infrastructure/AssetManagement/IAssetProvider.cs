using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(string path) where T : Object;
    }
}