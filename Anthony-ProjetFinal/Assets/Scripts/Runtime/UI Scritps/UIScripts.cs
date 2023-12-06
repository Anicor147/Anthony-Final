using Runtime.Managers;
using Runtime.Player;
using Runtime.Player.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI_Scritps
{
    public class UIScripts : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TMP_Text moneyCounterText;
        private int _moneyCounter;
        private PlayerController _playerController;
        
        private void Start()
        {
         _playerController = PlayerController.Instance;
         healthSlider.value = _playerController.CurrentHealth;
         
         EventManager.Instance.OnHealthChanged += UpdateHealthBar;
         EventManager.Instance.OnMoneyChanged += UpdateMoneyCounter;
         
        }
        
        public void UpdateHealthBar(int value)
        {
            healthSlider.value = value;
            Debug.Log($"HealthBar Slider value = {healthSlider.value}");
        }

        public void UpdateMoneyCounter(int value)
        {
            moneyCounterText.text = value.ToString();
        }

    }
}