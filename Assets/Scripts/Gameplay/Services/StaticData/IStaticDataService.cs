using UI.Configs;

namespace Gameplay.Services.StaticData
{
    public interface IStaticDataService
    {
        WindowStaticData WindowData { get; }
        void LoadAll();
    }
}