using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _maxHealth;
    private float _maxStamina;
    private float _expCap;
    private int _damage;
    public float CurrentHealth { get; set; }
    public float CurrenStamina{ get; set; }
    public float CurrentExp { get; set; }
    public int Damage { get; set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
        CurrenStamina = _maxStamina;
    }
    
    public void OnDamage(float damage)
    {
    }

    private void OnDeath()
    {
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(Damage);
        }
    }
    
}
