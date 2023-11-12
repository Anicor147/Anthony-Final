using UnityEngine;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameManager Instance { get; private set; }

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
