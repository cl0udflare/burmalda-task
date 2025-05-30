namespace Gameplay.Services.Input
{
    public interface IInputService
    {
        bool Jump { get; }
        bool Left { get; }
        bool Right { get; }
    }
}