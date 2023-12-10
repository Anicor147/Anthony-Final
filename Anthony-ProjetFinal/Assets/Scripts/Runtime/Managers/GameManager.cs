using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Runtime.Enemies;
using Runtime.Extensions;
using Runtime.Menu;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player1Object;
        [SerializeField] private GameObject player2Object;
        [SerializeField] private PlayerSelectionData playerSelectionData;
        private bool _isPlayer1;
        private bool _isPlayer2;

        public bool IsPlayer1
        {
            get => _isPlayer1;
            set => _isPlayer1 = value;
        }

        public bool IsPlayer2
        {
            get => _isPlayer2;
            set => _isPlayer2 = value;
        }

        public static GameManager Instance { get; private set; }
        internal static string SceneToLoad = "Level1";
         public static string CurrentScene = null;

        private void Awake()
        {
            Instance = this;
            Debug.Log("is player 1 after loading" + playerSelectionData.IsPlayer1Selected );
            Debug.Log("is player 2 after loading" + playerSelectionData.IsPlayer2Selected );
            CharactersSelection();
            CurrentScene = SceneToLoad;
            this.LoadScene(SceneToLoad, LoadSceneMode.Additive);
        }

        private void ResetValueSo()
        {
            playerSelectionData.ResetValue();
        }

        //Check Which Character is Selected
        private void CharactersSelection()
        {
            if (playerSelectionData.IsPlayer1Selected)
            {
                Debug.Log("should be sam");
                IsPlayer1 = true;
                IsPlayer2 = false;
                player1Object.SetActive(true);
                player2Object.SetActive(false);
            }
            else if (playerSelectionData.IsPlayer2Selected)
            {
                Debug.Log("Should be marth");
                IsPlayer1 = false;
                IsPlayer2 = true;
                player2Object.SetActive(true);
                player1Object.SetActive(false);
            }
            else
            {
                // Default
                Debug.Log("its default");
                IsPlayer1 = true;
                IsPlayer2 = false;
                player1Object.SetActive(true);
                player2Object.SetActive(false);
            }
        }

        internal static void LoadScene(string nextScene)
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            if (CurrentScene != null)
            {
                SceneManager.UnloadSceneAsync(CurrentScene);
            }

            CurrentScene = nextScene;
        }
    }
}