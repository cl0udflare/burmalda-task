using System;
using System.Collections.Generic;
using Infrastructure.States;
using Infrastructure.States.Factory;
using Infrastructure.States.Interfaces;
using Logging;
using Zenject;

namespace Infrastructure
{
    public class GameStateMachine : IInitializable
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        
        private readonly StateFactory _stateFactory;

        public GameStateMachine(StateFactory stateFactory) => 
            _stateFactory = stateFactory;

        public void Initialize()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = _stateFactory.CreateState<BootstrapState>(),
                [typeof(HomeScreenState)] = _stateFactory.CreateState<HomeScreenState>(),
                [typeof(GameplayState)] = _stateFactory.CreateState<GameplayState>(),
            };

            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : class, IState =>
            ChangeState<TState>().Enter();

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> =>
            ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;

            DebugLogger.LogMessage($"State changed to {_currentState.GetType().Name}", this);

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}