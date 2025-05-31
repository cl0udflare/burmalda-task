using Gameplay.Collects.Factory;
using Gameplay.Curtain.Factory.Curtain;
using Gameplay.Player.Factory;
using Gameplay.Services.Input;
using Gameplay.Services.StaticData;
using Infrastructure.AssetManagement;
using Infrastructure.Loading;
using Infrastructure.Services.Cameras;
using Infrastructure.Services.Coroutines;
using Infrastructure.States.Factory;
using Infrastructure.Systems;
using Logging;
using Progress.Provider;
using UI.Windows.Factory;
using UI.Windows.Services;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInfrastructure();
            BindProgress();
            BindUI();
            BindGameplay();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindInfrastructure()
        {
            // Factories
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
            // Services
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        private void BindProgress()
        {
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
        }

        private void BindGameplay()
        {
            // Services
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IInputService>().To<KeyboardInputService>().AsSingle();
            // Factories
            Container.Bind<ICurtainFactory>().To<CurtainFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<ICollectibleFactory>().To<CollectibleFactory>().AsSingle();
        }

        private void BindUI()
        {
            // Factories
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
            // Services
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        }
    }
}