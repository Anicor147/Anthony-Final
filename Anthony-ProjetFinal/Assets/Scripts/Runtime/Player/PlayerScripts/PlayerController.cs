using Runtime.Enemies;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {

        private int _maxHealth = 100;
        private float _maxStamina;
        private float _expCap;
        private int _damage;
        public int CurrentHealth { get; set; }
        public float CurrenStamina{ get; set; }
        public float CurrentExp { get; set; }
        public int Damage { get; set; }

        public static PlayerController Instance;

        private void Awake()
        {
            Instance = this;
            
            CurrentHealth = _maxHealth;
            CurrenStamina = _maxStamina;
        }
        
        public void OnDamage(int value)
        {
            CurrentHealth -= value;
            Debug.Log($"CurrentHealth is {CurrentHealth}");
            EventManager.Instance.TriggerHealthChangeEvent(CurrentHealth);
        }

        private void OnDeath()
        {
        }
    }
}
