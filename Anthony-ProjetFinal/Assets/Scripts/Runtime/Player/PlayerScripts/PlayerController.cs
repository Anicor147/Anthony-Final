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
        private int _moneyCount;
        public int CurrentHealth { get; set; }
        public float CurrenStamina{ get; set; }

        
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
            EventManager.Instance.TriggerOnCharacterHurt(true);
            if (CurrentHealth <= 0 )
            {
                OnDeath();
            }
        }

        public void IncreaseMoney( int value)
        {
            _moneyCount += value;
            EventManager.Instance.TriggerOnMoneyChanged(_moneyCount);
        }

        private void OnDeath()
        {
            EventManager.Instance.TriggerOnPlayerDead(true);
        }
    }
}
