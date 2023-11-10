using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float horizontal;
    private float vertical;
   [SerializeField] private float speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        FlipPlayer();
    }

    public void MoveInputs(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void MovePlayer()
    {
        _rigidbody2D.velocity = new Vector2(horizontal, vertical).normalized * speed ;
        var magnitude = _rigidbody2D.velocity.magnitude;
        EventManager.Instance.TriggerOnMovementEvent(magnitude);
    }

    private void FlipPlayer()
    {
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

}
