using Infrastructure.States.Interfaces;
using UI.Windows;
using UI.Windows.Services;

namespace Infrastructure.States.GameStates
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;

        public GameOverState(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        public void Enter()
        {
            _windowService.Open(WindowType.GameOver);
        }

        public void Exit()
        {
            _windowService.Close(WindowType.GameOver);
        }
    }
}