using System;
using Progress.Services.Provider;

namespace Progress.Services.Economy
{
    public class EconomyService : IEconomyService
    {
        private readonly IProgressProvider _progressProvider;
        
        public int SoftCurrency => _progressProvider.Economy.SoftCurrency;
        
        public event Action OnCurrencyChanged;

        public EconomyService(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }
        
        public bool IncreaseCurrency(int value)
        {
            if (SoftCurrency + value < 0) 
                return false;
            
            value += SoftCurrency;
            UpdateProgress(value);
            
            return true;
        }
        
        public bool DecreaseCurrency(int value)
        {
            if (SoftCurrency < value) 
                return false;
            
            value -= SoftCurrency;
            UpdateProgress(value);

            return true;
        }

        private void UpdateProgress(int value)
        {
            _progressProvider.Economy.SoftCurrency = value;
            OnCurrencyChanged?.Invoke();
        }
    }
}