using System;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        [SerializeField] private PlayerSelectionData playerSelectionData;
        private bool _fromMenu;
        public bool FromMenu { get => _fromMenu; private set => _fromMenu = value; }
        public static CharacterSelectScripts Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _fromMenu = true;
        }

        //Choose Character1
        public void SelectPlayer1()
        {
          playerSelectionData.IsPlayer1Selected = true;
          playerSelectionData.IsPlayer2Selected = false;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            playerSelectionData.IsPlayer1Selected = false;
            playerSelectionData.IsPlayer2Selected = true;
            this.LoadScene("Level1", LoadSceneMode.Single);
        }
    }
}