using Infrastructure.AssetManagement;
using Logic.Curtain;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories.Curtain
{
    public class CurtainFactory : ICurtainFactory
    {
        private const string CURTAIN_PATH = "UI/Curtain";

        private readonly IAssetProvider _assetProvider;
        private LoadingCurtain _curtain;

        public LoadingCurtain Curtain => GetCurtain();

        public CurtainFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        private LoadingCurtain GetCurtain()
        {
            if (!_curtain) 
                CreateCurtain();
            
            return _curtain;
        }

        private void CreateCurtain()
        {
            LoadingCurtain prefab = _assetProvider.Load<LoadingCurtain>(CURTAIN_PATH);
            _curtain = Object.Instantiate(prefab);
            Object.DontDestroyOnLoad(_curtain.gameObject);
        }
    }
}