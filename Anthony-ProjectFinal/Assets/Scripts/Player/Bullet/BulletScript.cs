using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;
    private bool playerIsLeft;
    private bool eventHandled;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        EventManager.Instance.onPlayerSideChanged += PlayerSideCheck ;
    }

    private void FixedUpdate()
    {
        if (!eventHandled)
        {
            ProjectileMovement();
            eventHandled = true;
        }
    }

    private void PlayerSideCheck(bool side)
    {
        playerIsLeft = side;
    }

    public void ProjectileMovement()
    {
        if (playerIsLeft)
        {
            Debug.Log($"speed?");
            _rigidbody2D.velocity = -transform.right * speed;
        }
        else if(!playerIsLeft)
        {
            Debug.Log(playerIsLeft);
            _rigidbody2D.velocity = transform.right * speed;
        }


    }


}
