using Progress.Data;

namespace Progress.Services.Provider
{
    public interface IProgressProvider
    {
        EconomyData Economy { get; }
        void SetEconomyData(EconomyData data);
    }
}