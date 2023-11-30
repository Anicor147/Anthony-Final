using System;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        public static CharacterSelectScripts Instance { get; private set; }

        private bool _isPlayer1;
        private bool _isPlayer2;
        public bool IsPlayer1 { get; private set; }

        public bool IsPlayer2 { get; private set; }


        private void Awake()
        {
            Instance = this;
        }

        //Choose Character1
        public void SelectPlayer1()
        {
            IsPlayer1 = true;
            IsPlayer2 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            IsPlayer2 = true;
            IsPlayer1 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }
    }
}