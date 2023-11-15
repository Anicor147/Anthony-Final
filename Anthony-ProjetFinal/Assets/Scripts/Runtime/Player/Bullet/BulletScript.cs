using System;
using Runtime.Enemies;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Bullet
{
    public class BulletScript : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private float speed;
        private bool _playerIsLeft;
        private bool _eventHandled;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
        private void Start()
        {
            //Subscribe to Event - Source PlayerMovement 
            EventManager.Instance.OnPlayerSideChanged += value => _playerIsLeft = value ;
        }

        private void FixedUpdate()
        {
            // Projectile Movement only called once
            if (_eventHandled) return;
            ProjectileMovement();
            _eventHandled = true;
        }
        
        //Send Bullet to right or left
        public void ProjectileMovement()
        {
            if (_playerIsLeft)
            {
                _spriteRenderer.flipX = true;
                _rigidbody2D.velocity = -transform.right * speed;
            }
            else if(!_playerIsLeft)
            {
                _rigidbody2D.velocity = transform.right * speed;
                _spriteRenderer.flipX = false;
            }
        }

        //Check for Collision
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyBase>().TakeDamage(100);
                DestroyBulletPrefab();
            }
        }

        // TODO replace for Object Pooling
        void DestroyBulletPrefab()
        {
            //Unsubscribe before destroy
            EventManager.Instance.OnPlayerSideChanged -= value => _playerIsLeft = value ;
            Destroy(gameObject);
        }
    }
}
