using System;
using log4net.Core;
using Runtime.Extensions;
using Runtime.Managers;
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
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private GameObject player;
        private bool isPushBack;
        [FormerlySerializedAs("_loot")] [SerializeField] private LootManager loot;
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

        //Received Damage
        public override void TakeDamage(int value)
        {
            MaxEHealth -= value;
            _spriteRenderer.material.SetFloat("_HitValue",1);
            //Timer extensions , set material value to 0
            this.StartTimer(0.2f , () =>_spriteRenderer.material.SetFloat("_HitValue",0));
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
            Destroy(gameObject);
        }
        //Goes toward player
        public override void EnemyMovement()
        {
            if (isPushBack)return;
            
            Vector3 x = player.transform.position - transform.position;
            _rigidbody2D.velocity = x.normalized * Espeed;
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
            Debug.Log($"should be {pushback}");
            isPushBack = true;
            _rigidbody2D.AddForce(pushback.normalized * 10f, ForceMode2D.Impulse);
            Debug.Log("Tiger Should knockback");
            this.StartTimer(1f, () => isPushBack=false) ;
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Enemy attack player");
                other.gameObject.GetComponent<PlayerController>().OnDamage(EDamage);
                PushBack(other);
            }
        }
    }
}