using System;
using Runtime.Enemies;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Bullet
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private int bulletDamage;
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private bool _playerIsLeft;
        private bool _eventHandled;
        private float _timeToLive = 0.1f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            //Subscribe to Event - Source PlayerMovement 
            // EventManager.Instance.OnPlayerSideChanged += value => _playerIsLeft = value ;
        }

        private void OnEnable()
        {
            EventManager.Instance.OnPlayerSideChanged += value => _playerIsLeft = value;
            Debug.Log("Should be subcribed again");
        }

        private void FixedUpdate()
        {
            // Projectile Movement only called once
            if (_eventHandled) return;
            ProjectileMovement();
            _eventHandled = true;
        }

        private void Update()
        {
            _timeToLive -= Time.deltaTime;
            if (_timeToLive <= 0)
            {
                Reset();
            }
        }

        //Send Bullet to right or left
        public void ProjectileMovement()
        {
            if (_playerIsLeft)
            {
                _spriteRenderer.flipX = true;
                _rigidbody2D.velocity = -transform.right * speed;
            }
            else if (!_playerIsLeft)
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
                other.gameObject.GetComponent<EnemyBase>().TakeDamage(bulletDamage);
                Reset();
            }
        }

        public void Reset()
        {
            //Unsubscribe before destroy
            EventManager.Instance.OnPlayerSideChanged -= value => _playerIsLeft = value;
            _eventHandled = false;
            _timeToLive = 5f;
            gameObject.SetActive(false);
        }
    }
}