using Logic.Curtain;

namespace Infrastructure.Factories.Curtain
{
    public interface ICurtainFactory
    {
        LoadingCurtain Curtain { get; }
    }
}