using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
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
        //Sent To Event for PlayerAnimationController
        EventManager.Instance.TriggerOnMovementEvent(magnitude);
    }

    private void FlipPlayer()
    {
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(horizontal > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }

}
