using System;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        private bool _isPlayer1;
        private bool _isPlayer2;
        public bool IsPlayer1 { get => _isPlayer1; private set => _isPlayer1 = value; }

        public bool IsPlayer2 { get => _isPlayer2; private set => _isPlayer2 = value; }
        public static CharacterSelectScripts Instance { get; private set; }

        
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        //Choose Character1
        public void SelectPlayer1()
        {
            _isPlayer1 = true;
            _isPlayer2 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            _isPlayer2 = true;
            _isPlayer1 = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }
    }
}