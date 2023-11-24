using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        public static  bool isPlayer1;
        public static  bool isPlayer2;
        
        //Choose Character1
        public void SelectPlayer1()
        {
            isPlayer1 = true;
            isPlayer2 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            isPlayer2 = true;
            isPlayer1 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }


    }
}
