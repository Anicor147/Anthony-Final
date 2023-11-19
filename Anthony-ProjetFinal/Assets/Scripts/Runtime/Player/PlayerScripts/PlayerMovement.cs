using System;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Player.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private float horizontal;
        private float vertical;
        [SerializeField] private float speed;
        private bool playerIsThrowing;
        private Vector3 currentPostion;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            //Subscribe to Event - Source PlayerAttack 
            EventManager.Instance.OnThrowingChanged += value => playerIsThrowing = value;
        }

        private void FixedUpdate()
        {
            MovePlayer();
            FlipPlayer();
            localScaleCheck();
        }

        private void Update()
        {
            GetPlayerPosition();
        }

        //Get Player Position + announce changes
        private void GetPlayerPosition()
        {
            if (currentPostion == gameObject.transform.position) return;
            EventManager.Instance.TriggerCharacterMovement(gameObject.transform.position);
            currentPostion = gameObject.transform.position;
        }


        public void MoveInputs(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
            vertical = context.ReadValue<Vector2>().y;
        }

        public void MovePlayer()
        {
            if (playerIsThrowing)return;
            _rigidbody2D.velocity = new Vector2(horizontal, vertical).normalized * speed ;
            var magnitude = _rigidbody2D.velocity.magnitude;
            //Sent To Event for PlayerAnimationController
            EventManager.Instance.TriggerOnMovementEvent(magnitude);
        }

        private void FlipPlayer()
        {
            if (horizontal < 0)
            {
                //left
                transform.localScale = new Vector3(-1,1,1);
            }
            else if(horizontal > 0)
            {
                //right
                transform.localScale = new Vector3(1,1,1);
            }
        }

        //Check Character side
        private void localScaleCheck()
        {
            if (transform.localScale.x < 0)
            {
                EventManager.Instance.TriggerOnPlayerSideChanged(true);
            }
            else
            {
                EventManager.Instance.TriggerOnPlayerSideChanged(false);
            }
        }

    }
}
