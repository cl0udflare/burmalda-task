using Gameplay.Curtain;

namespace Gameplay.Factories.Curtain
{
    public interface ICurtainFactory
    {
        LoadingCurtain Curtain { get; }
    }
}