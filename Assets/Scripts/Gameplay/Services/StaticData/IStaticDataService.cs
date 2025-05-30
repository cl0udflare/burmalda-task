using Gameplay.Player.Configs;
using UI.Configs;

namespace Gameplay.Services.StaticData
{
    public interface IStaticDataService
    {
        WindowStaticData WindowData { get; }
        PlayerConfig PlayerConfig { get; }
        void LoadAll();
    }
}