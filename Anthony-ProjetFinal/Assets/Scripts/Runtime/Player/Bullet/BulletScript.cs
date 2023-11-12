using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Bullet
{
    public class BulletScript : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed;
        private bool _playerIsLeft;
        private bool _eventHandled;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        private void Start()
        {
            EventManager.Instance.OnPlayerSideChanged += PlayerSideCheck ;
        }

        private void FixedUpdate()
        {
            if (!_eventHandled)
            {
                ProjectileMovement();
                _eventHandled = true;
            }
        }

        private void PlayerSideCheck(bool side)
        {
            _playerIsLeft = side;
        }

        public void ProjectileMovement()
        {
            if (_playerIsLeft)
            {
                Debug.Log($"speed?");
                _rigidbody2D.velocity = -transform.right * speed;
            }
            else if(!_playerIsLeft)
            {
                Debug.Log(_playerIsLeft);
                _rigidbody2D.velocity = transform.right * speed;
            }
        }


    }
}
