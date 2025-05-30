using Infrastructure.AssetManagement;
using Infrastructure.Factories.Curtain;
using Infrastructure.Factories.State;
using Infrastructure.Loading;
using Logging;
using Services.CoroutineRunner;
using Zenject;

namespace Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            
            BindInfrastructureFactories();
            BindCommonServices();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindInfrastructureFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<ICurtainFactory>().To<CurtainFactory>().AsSingle();
        }
        
        private void BindCommonServices()
        {
            Container.Bind<ICoroutineRunnerService>().To<CoroutineRunnerService>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}