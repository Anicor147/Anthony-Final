using Runtime.Enemies;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Grenade
{
    public class GrenadeDamageLogic : MonoBehaviour
    {
        [SerializeField] private int grenadeDamage;
        private Animator _animator;
        private bool _isExploding;
        private float _timer = 0.5f;
        private bool _startTimer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_startTimer)
            {
                TimerExplosion();
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Enemy")) return;
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(grenadeDamage);
            _animator.SetBool("isExploding", true);
            SoundEffectManager.Instance.PlayExplosionSound();
            _startTimer = true;
        }

        private void TimerExplosion()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                OnDestroyGrenade();
            }
        }

        private void OnDestroyGrenade()
        {
            Destroy(gameObject);
        }
    }
}