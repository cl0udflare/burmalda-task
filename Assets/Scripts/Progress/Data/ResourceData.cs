using System;
using UnityEngine;

namespace Progress.Data
{
    [Serializable]
    public class ResourceData
    {
        [SerializeField] private int _coins;
        public int Coins => _coins;
        public event Action OnCoinsChanged;
        
        public void AddCoins(int coins)
        {
            OnCoinsChanged?.Invoke();
            _coins += coins;
        }
    }
}