using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScripts : MonoBehaviour
{
    public static  bool _isPlayer1 = false;
    public static  bool _isPlayer2 = false;



    public void SelectPlayer1()
    {
        _isPlayer1 = true;
        this.LoadScene("Level1", LoadSceneMode.Single);

    }

    public void SelectPlayer2()
    {
        _isPlayer2 = true;
        this.LoadScene("Level1", LoadSceneMode.Single);

    }


}
