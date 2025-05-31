using Infrastructure.States.Interfaces;
using Zenject;

namespace Infrastructure.States.Factory
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) =>
            _container = container;

        public TState CreateState<TState>() where TState : IExitableState =>
            _container.Resolve<TState>();
    }
}