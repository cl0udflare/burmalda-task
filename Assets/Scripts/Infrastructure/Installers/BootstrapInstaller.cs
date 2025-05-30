using Gameplay.Factories.Curtain;
using Gameplay.Services.StaticData;
using Infrastructure.Factories.State;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.CoroutineRunner;
using Infrastructure.Services.Loading;
using Logging;
using UI.Factories;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInfrastructureFactories();
            BindInfrastructureServices();
            
            BindUIFactories();
            BindUIServices();
            
            BindGameplayServices();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindInfrastructureFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<ICurtainFactory>().To<CurtainFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindUIFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }
    }
}