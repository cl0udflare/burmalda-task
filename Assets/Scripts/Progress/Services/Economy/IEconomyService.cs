using System;

namespace Progress.Services.Economy
{
    public interface IEconomyService
    {
        event Action OnCurrencyChanged;
        int SoftCurrency { get; }
        bool IncreaseCurrency(int value);
        bool DecreaseCurrency(int value);
    }
}