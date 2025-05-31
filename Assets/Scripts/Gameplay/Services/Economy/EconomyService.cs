using System;

namespace Gameplay.Services.Economy
{
    public class EconomyService : IEconomyService
    {
        public event Action OnCurrencyChanged;
        
        public int SoftCurrency {private set; get; }

        public bool IncreaseCurrency(int value)
        {
            if (SoftCurrency + value < 0) 
                return false;
            
            SoftCurrency += value;
            OnCurrencyChanged?.Invoke();
            
            return true;
        }
        
        public bool DecreaseCurrency(int value)
        {
            if (SoftCurrency < value) 
                return false;
            
            SoftCurrency -= value;
            OnCurrencyChanged?.Invoke();

            return true;
        }
    }
}