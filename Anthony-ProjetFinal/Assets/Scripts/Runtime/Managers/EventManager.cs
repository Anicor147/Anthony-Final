using System;
using UnityEngine;

namespace Runtime.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }
        public event Action<int> OnHealthChanged; 
        public event Action<float> OnMagnitudeChanged;
        public event Action<bool> OnShootingChanged;
        public event Action<bool> OnThrowingChanged;
        public event Action<bool> OnPlayerSideChanged; 
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void TriggerHealthChangeEvent(int health)
        {
            OnHealthChanged?.Invoke(health);
        }

        public void TriggerOnMovementEvent(float magnitude)
        {
            OnMagnitudeChanged?.Invoke(magnitude);
        }

        public void TriggerOnShootingEvent(bool isShooting)
        {
            OnShootingChanged?.Invoke(isShooting);
        }

        public void TriggerOnThrowingEvent(bool throwing)
        {
            OnThrowingChanged?.Invoke(throwing);
        }

        public void TriggerOnPlayerSideChanged(bool side)
        {
            OnPlayerSideChanged?.Invoke(side);
        }
    }
}
