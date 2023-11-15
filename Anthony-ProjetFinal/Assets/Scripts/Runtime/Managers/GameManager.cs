using System.Collections.Generic;
using Runtime.Enemies;
using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameManager Instance { get; private set; }
        private List<EnemyBase> _enemyList;
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        
        }
    
        void Update()
        {
        
        }
    }
}
