using Runtime.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Player.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _currentPosition;

        private float _horizontal;
        private float _vertical;
        private bool _playerIsThrowing;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            //Subscribe to Event - Source PlayerAttack 
            EventManager.Instance.OnThrowingChanged += value => _playerIsThrowing = value;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnThrowingChanged -= value => _playerIsThrowing = value;
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
            if (_currentPosition == gameObject.transform.position) return;
            EventManager.Instance.TriggerCharacterMovement(gameObject.transform.position);
            _currentPosition = gameObject.transform.position;
        }


        public void MoveInputs(InputAction.CallbackContext context)
        {
            _horizontal = context.ReadValue<Vector2>().x;
            _vertical = context.ReadValue<Vector2>().y;
        }

        public void MovePlayer()
        {
            if (_playerIsThrowing) return;
            _rigidbody2D.velocity = new Vector2(_horizontal, _vertical).normalized * speed;
            var magnitude = _rigidbody2D.velocity.magnitude;
            //Sent To Event for PlayerAnimationController
            EventManager.Instance.TriggerOnMovementEvent(magnitude);
        }

        private void FlipPlayer()
        {
            if (_horizontal < 0)
            {
                //left
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_horizontal > 0)
            {
                //right
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        //Check Character side
        private void localScaleCheck()
        {
            bool isFacingLeft = transform.localScale.x < 0;
            EventManager.Instance.TriggerOnPlayerSideChanged(isFacingLeft);
        }
    }
}