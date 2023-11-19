using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        public static  bool _isPlayer1 = false;
        public static  bool _isPlayer2 = false;
        
        //Choose Character1
        public void SelectPlayer1()
        {
            _isPlayer1 = true;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            _isPlayer2 = true;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }


    }
}
