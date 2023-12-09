using Runtime.Player.PlayerScripts;
using UnityEngine;

namespace Runtime.Enemies
{
    public class EnemyBullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        public float projectileSpeed = 10f;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Invoke("DestroyProjectile",5f);
        }
        
        private void FixedUpdate()
        {
            ProjectileMovement();
        }
        
        private void ProjectileMovement()
        {
            _rigidbody2D.velocity = transform.right * projectileSpeed ;
        }
        public void DestroyProjectile()
        {
            Destroy(gameObject);
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("should Damage");
                other.gameObject.GetComponent<PlayerController>().OnDamage(5);
                Destroy(gameObject);
            }
        }
    }
}