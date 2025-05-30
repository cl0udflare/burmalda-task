using Infrastructure.Factories.State;
using Logging;
using Zenject;

namespace Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();

            DebugLogger.LogMessage("Install", this);
        }

        private void BindFactories()
        {
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}