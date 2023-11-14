using System;
using Runtime.Enemies;
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
                _rigidbody2D.velocity = -transform.right * speed;
            }
            else if(!_playerIsLeft)
            {
                _rigidbody2D.velocity = transform.right * speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Is true");
                other.gameObject.GetComponent<EnemyBase>().TakeDamage(1);
                DestroyBulletPrefab();
            }
        }

        // TODO replace for Object Pooling
        void DestroyBulletPrefab()
        {
            Debug.Log($"should Unsubscribe");
            EventManager.Instance.OnPlayerSideChanged -= PlayerSideCheck ;
            Debug.Log($"should Destroy");
            Destroy(gameObject);
        }
    }
}
