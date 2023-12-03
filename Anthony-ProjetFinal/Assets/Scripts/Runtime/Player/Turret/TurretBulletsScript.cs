using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Enemies;
using UnityEngine;

public class TurretBulletsScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private GameObject turretScale;
    private bool side;
    public static TurretBulletsScript Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        if (!side)
        {
            _rigidbody2D.velocity = transform.right * speed;
        }
        else if (side)
        {
            _rigidbody2D.velocity = -transform.right * speed;
        }
    }

    public bool Scale(Transform scale)
    {
        if (scale.localScale.x == -1)
        {Debug.Log("should be right");
            side = true;
            return side;
        }
        else if (scale.localScale.x == 1)
        {
            Debug.Log("should be left ");
            side = false;
            return side;    
        }

        return side;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        other.gameObject.GetComponent<EnemyBase>().TakeDamage(bulletDamage);
        DestroyBulletPrefab();
    }

    void DestroyBulletPrefab()
    {
        Destroy(gameObject);
    }
}