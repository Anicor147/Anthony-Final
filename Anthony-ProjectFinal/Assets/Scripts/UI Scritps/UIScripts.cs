using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
    public class UIScripts : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        private PlayerController _playerController;

        private void Start()
        {
         _playerController = PlayerController.Instance;
         healthSlider.value = _playerController.CurrentHealth;
         
         EventManager.Instance.OnHealthChanged += UpdateHealthBar;
        }


        public void UpdateHealthBar(int value)
        {
            healthSlider.value -= value;
        }
    }
}