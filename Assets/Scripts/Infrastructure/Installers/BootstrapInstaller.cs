using Gameplay.Collects.Factory;
using Gameplay.Curtain.Factory.Curtain;
using Gameplay.Player.Factory;
using Gameplay.Services.Input;
using Gameplay.Services.StaticData;
using Infrastructure.AssetManagement;
using Infrastructure.Loading;
using Infrastructure.Services.Coroutines;
using Infrastructure.States.Factory;
using Infrastructure.Systems;
using Logging;
using UI.Factory;
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
            
            BindGameplayFactories();
            BindGameplayServices();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindInfrastructureFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
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

        private void BindGameplayFactories()
        {
            Container.Bind<ICurtainFactory>().To<CurtainFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<ICollectibleFactory>().To<CollectibleFactory>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IInputService>().To<KeyboardInputService>().AsSingle().NonLazy();
        }
    }
}