using Gameplay.Services.Economy;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class EconomyCounter : MonoBehaviour
    {
        [SerializeField] public TMP_Text _softCurrencyText;
        
        private IEconomyService _economyService;

        [Inject]
        private void Construct(IEconomyService economyService)
        {
            _economyService = economyService;
        }

        private void Start()
        {
            _economyService.OnCurrencyChanged += UpdateCount;
            UpdateCount();
        }

        private void OnDestroy() => 
            _economyService.OnCurrencyChanged -= UpdateCount;

        private void UpdateCount() => 
            _softCurrencyText.text = $"{_economyService.SoftCurrency}";
    }
}