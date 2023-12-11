using UnityEngine;

namespace Runtime.ScriptableObjects.SOScripts
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/PlayerStats", order = 0)]
    public class PlayerStatsSOScritps : ScriptableObject
    {
        public float _maxHealth;
        public float _maxStamina;
        public float _expCap;
    }
}