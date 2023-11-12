using Runtime.Managers;
using Runtime.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI_Scritps
{
    public class UIScripts : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        private PlayerController _playerController;

        private void Start()
        {
         _playerController = PlayerController.Instance;
         healthSlider.value = _playerController.CurrentHealth;
         Debug.Log($"HealthBar Slider value = {healthSlider.value}");
         EventManager.Instance.OnHealthChanged += UpdateHealthBar;
        }
        
        public void UpdateHealthBar(int value)
        {
            healthSlider.value = value;
            Debug.Log($"HealthBar Slider value = {healthSlider.value}");
        }
    }
}