using UnityEngine;

namespace Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public float MaxEHealth { get; set; }

        public float Espeed { get; set; }

        public float EexpDrop { get; set; }

        public float EDamage { get; set; }

        public abstract void TakeDamage(int value);
        public abstract void OnDeath();
        public abstract void EnemyMovement();
    }
}