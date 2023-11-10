using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public event Action<int> OnHealthChanged; 
    public event Action<float> OnMagnitudeChanged; 
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

}
