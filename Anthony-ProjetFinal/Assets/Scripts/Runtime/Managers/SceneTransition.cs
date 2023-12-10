using UnityEngine;

namespace Runtime.Managers
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] private string nextScene;

        void delays()
        {
            GameManager.LoadScene(nextScene);
        }
    }
}