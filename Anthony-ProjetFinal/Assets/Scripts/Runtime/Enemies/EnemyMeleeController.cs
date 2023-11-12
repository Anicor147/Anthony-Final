using Runtime.Player;
using Runtime.ScriptableObjects.SOScripts;
using UnityEngine;

namespace Runtime.Enemies
{
    public class EnemyMeleeController : EnemyBase
    {
        [SerializeField] private EnemyStatsSOScritps _enemyStatsSoScritps;
        private Rigidbody2D _rigidbody2D;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            MaxEHealth = _enemyStatsSoScritps.MaxEHealth;
            Espeed = _enemyStatsSoScritps.Espeed;
            EexpDrop = _enemyStatsSoScritps.EexpDrop;
            EDamage = _enemyStatsSoScritps.EDamage;
        }
        
        public override void TakeDamage(int value)
        {
            MaxEHealth -= value;

            if (MaxEHealth <= 0)
            {
                OnDeath();
            }
        }

        public override void OnDeath()
        {
            Destroy(gameObject);
        }

        public override void EnemyMovement()
        {
            throw new System.NotImplementedException();
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