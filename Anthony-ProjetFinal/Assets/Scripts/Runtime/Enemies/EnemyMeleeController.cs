using System;
using Runtime.Extensions;
using Runtime.Player;
using Runtime.Player.PlayerScripts;
using Runtime.ScriptableObjects.SOScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Enemies
{
    public class EnemyMeleeController : EnemyBase
    {
        [SerializeField] private EnemyStatsSOScritps _enemyStatsSoScritps;
        [SerializeField] private LayerMask layerMask;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private GameObject player;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            MaxEHealth = _enemyStatsSoScritps.MaxEHealth;
            Espeed = _enemyStatsSoScritps.Espeed;
            EexpDrop = _enemyStatsSoScritps.EexpDrop;
            EDamage = _enemyStatsSoScritps.EDamage;
            ERange = 10;
        }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
            EnemyMovement();
            FlipSprite();
        }

        public override void TakeDamage(int value)
        {
            MaxEHealth -= value;
            _spriteRenderer.material.SetFloat("_HitValue",1);
            this.StartTimer(0.2f,ResetMaterialColor );
            if (MaxEHealth <= 0)
            {
                OnDeath();
            }
        }

        void ResetMaterialColor()
        {
            _spriteRenderer.material.SetFloat("_HitValue",0);
        }

        public override void OnDeath()
        {
            Destroy(gameObject);
        }
        public override void EnemyMovement()
        {
            Vector3 x = player.transform.position - transform.position;

            _rigidbody2D.velocity = x.normalized * Espeed;
        }
        public override void FlipSprite()
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerController>().OnDamage(EDamage);
            }
        }
    }
}