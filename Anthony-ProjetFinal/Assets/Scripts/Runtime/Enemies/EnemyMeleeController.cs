using Runtime.Extensions;
using Runtime.Managers;
using Runtime.Player.PlayerScripts;
using Runtime.ScriptableObjects.SOScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Enemies
{
    public class EnemyMeleeController : EnemyBase
    {
        [SerializeField] private EnemyStatsSOScritps _enemyStatsSoScritps;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private GameObject player;
        private bool isPushBack;

        [FormerlySerializedAs("_loot")] [SerializeField]
        private LootManager loot;

        private Animator _animator;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            MaxEHealth = _enemyStatsSoScritps.MaxEHealth;
            ESpeed = _enemyStatsSoScritps.Espeed;
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

        //Received Damage
        public override void TakeDamage(int value)
        {
            MaxEHealth -= value;
            _spriteRenderer.material.SetFloat("_HitValue", 1);
            //Timer extensions , set material value to 0
            this.StartTimer(0.2f, () => _spriteRenderer.material.SetFloat("_HitValue", 0));
            if (MaxEHealth <= 0)
            {
                OnDeath();
            }
        }

        public override void OnDeath()
        {
            //LevelManager.Instance._enemyList.Remove(gameObject);
            EnemyKilledCounter.Instance.EnemyCounter++;
            loot.MoneyLoot(transform.position);
            _animator.SetTrigger("IsDead");
            SoundEffectManager.Instance.PlayExplosionSound();
            this.StartTimer(0.5f, () => Destroy(gameObject));
        }

        //Goes toward player
        public override void EnemyMovement()
        {
            if (isPushBack) return;

            Vector3 x = player.transform.position - transform.position;
            _rigidbody2D.velocity = x.normalized * ESpeed;
        }

        //Flip Sprite
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

        //PushBack from the player 
        private void PushBack(Collision2D other)
        {
            var pushback = transform.position - other.transform.position;
            isPushBack = true;
            _rigidbody2D.AddForce(pushback.normalized * 10f, ForceMode2D.Impulse);
            this.StartTimer(1f, () => isPushBack = false);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerController>().OnDamage(EDamage);
                PushBack(other);
            }
        }
    }
}