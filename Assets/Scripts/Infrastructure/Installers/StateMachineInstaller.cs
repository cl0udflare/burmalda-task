using Infrastructure.States;
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

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle(); // ENTRY POINT
           
            DebugLogger.LogMessage("Install", this);
        }

        public void Initialize()
        {
            Application.targetFrameRate = 90;
        }
    }
}