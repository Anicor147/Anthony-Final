using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

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
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;
        CurrenStamina = _maxStamina;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(Damage);
        }
    }

    public void OnDamage(int value)
    {
        CurrentHealth -= value;
        EventManager.Instance.TriggerHealthChangeEvent(CurrentHealth);
    }

    private void OnDeath()
    {
    }
}
