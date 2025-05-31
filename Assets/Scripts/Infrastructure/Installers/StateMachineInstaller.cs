using Infrastructure.States;
using Infrastructure.States.GameStates;
using Logging;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class StateMachineInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<HomeScreenState>().AsSingle().NonLazy();
            Container.Bind<GameplayState>().AsSingle().NonLazy();
            Container.Bind<GameOverState>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle(); //TODO: Entry point
           
            DebugLogger.LogMessage("Install", this);
        }

        public void Initialize()
        {
            Application.targetFrameRate = 90;
        }
    }
}