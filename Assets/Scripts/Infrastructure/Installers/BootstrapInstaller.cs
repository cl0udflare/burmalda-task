using Gameplay.Factories.Curtain;
using Gameplay.Player.Factory;
using Gameplay.Services.Input;
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
            
            BindGameplayFactories();
            BindGameplayServices();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindInfrastructureFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
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
        }

        private void BindGameplayServices()
        {
            Container.Bind<IInputService>().To<KeyboardInputService>().AsSingle().NonLazy();
        }
    }
}