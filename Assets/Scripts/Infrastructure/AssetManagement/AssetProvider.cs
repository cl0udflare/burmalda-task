using System.Threading.Tasks;
using Logging;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public async Task<T> Load<T>(string path) where T : Object
        {
            ResourceRequest request = Resources.LoadAsync<T>(path);

            TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
            request.completed += OnCompleted;
            
            await completionSource.Task;
            
            if (request.asset) 
                return request.asset as T;
            
            DebugLogger.LogError($"Failed to load asset at path: {path}");
            return null;

            void OnCompleted(AsyncOperation operation)
            {
                request.completed -= OnCompleted;
                completionSource.SetResult(true);
            }
        }
    }
}