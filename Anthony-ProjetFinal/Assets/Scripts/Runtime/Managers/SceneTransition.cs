using System.Collections;
using UnityEngine;

namespace Runtime.Managers
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private string nexScene;
        
        void Start()
        {
            Invoke(nameof(delays) , 5f);
        }
        void delays()
        {
            GameManager.LoadScene(nexScene);
        }
    }
}
