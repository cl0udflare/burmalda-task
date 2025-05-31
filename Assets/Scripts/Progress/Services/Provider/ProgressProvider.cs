using Progress.Data;

namespace Progress.Services.Provider
{
    public class ProgressProvider : IProgressProvider
    {
        public EconomyData Economy { get; private set; }

        public void SetEconomyData(EconomyData data) => Economy = data;
    }
}