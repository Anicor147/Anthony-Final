using UnityEngine;

namespace Runtime.ScriptableObjects.SOScripts
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "SO/EnemyStats", order = 1)]
    public class EnemyStatsSOScritps : ScriptableObject
    {
        public float MaxEHealth;
        public float Espeed;
        public float EexpDrop;
        public int EDamage;
    }
}