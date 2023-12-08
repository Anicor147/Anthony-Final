using System;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        [SerializeField] private PlayerSelectionData playerSelectionData;

        [SerializeField] private GameObject levelSelectionMenu;

        // private bool _fromMenu;
        //public bool FromMenu { get => _fromMenu; private set => _fromMenu = value; }
        //public static CharacterSelectScripts Instance { get; private set; }

        private void Awake()
        {
            // Instance = this;
        }

        private void Start()
        {
            //  _fromMenu = true;
            playerSelectionData.ResetValue();
            Debug.Log("is player 1 after reset" + playerSelectionData.IsPlayer1Selected );
            Debug.Log("is player 2 after reset" + playerSelectionData.IsPlayer2Selected );
        }

        //Choose Character1
        public void SelectPlayer1()
        {
            playerSelectionData.IsPlayer1Selected = true;
            playerSelectionData.IsPlayer2Selected = false;
            levelSelectionMenu.SetActive(true);
            Debug.Log("is player 1" + playerSelectionData.IsPlayer1Selected );
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            playerSelectionData.IsPlayer1Selected = false;
            playerSelectionData.IsPlayer2Selected = true;
            Debug.Log("is player 2" + playerSelectionData.IsPlayer2Selected );
            // this.LoadScene("Level1", LoadSceneMode.Single);
            levelSelectionMenu.SetActive(true);
        }
    }
}