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
        internal static string CurrentScene = null;

        private void Awake()
        {
            Instance = this;
            CharactersSelection();
            CurrentScene = SceneToLoad;
            this.LoadScene(SceneToLoad, LoadSceneMode.Additive);
        }

        //Check Which Character is Selected
        private void CharactersSelection()
        {
            //Default
            if (CharacterSelectScripts.Instance == null)
            {
                IsPlayer1 = true;
                player1Object.SetActive(true);
                player2Object.SetActive(false);
                return;
            }

            if (CharacterSelectScripts.Instance.IsPlayer1)
            {
                Debug.Log("Should be Sam");
                IsPlayer1 = true;
                player1Object.SetActive(true);
                player2Object.SetActive(false);
            }
            else if (CharacterSelectScripts.Instance.IsPlayer2)
            {
                Debug.Log("Should be Mart");
                IsPlayer2 = true;
                player2Object.SetActive(true);
                player1Object.SetActive(false);
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