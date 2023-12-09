using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class LevelSelectionScript : MonoBehaviour
    {
        public void LoadLevel1()
        {
            this.LoadScene("Level1", LoadSceneMode.Single);
        }
        
        public void LoadLevel2()
        {
            this.LoadScene("Level2", LoadSceneMode.Single);
        }
        
        public void LoadLevel3()
        {
            this.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}