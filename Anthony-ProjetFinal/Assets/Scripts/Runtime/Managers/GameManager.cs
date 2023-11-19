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
        public static GameManager Instance { get; private set; }
        internal static string SceneToLoad = "Level1";
        internal static string CurrentScene = null;
        private void Awake()
        {
            Instance = this;
            CharactersSelection();
            CurrentScene = SceneToLoad;
            this.LoadScene(SceneToLoad ,LoadSceneMode.Additive);
        }

        //Check Which Character is Selected
        private void CharactersSelection()
        {
            if (CharacterSelectScripts._isPlayer1)
            {
               player1Object.SetActive(true);
               player2Object.SetActive(false);
               CharacterSelectScripts._isPlayer2 = false;
            }
            else if (CharacterSelectScripts._isPlayer2)
            {
                player2Object.SetActive(true);
                player1Object.SetActive(false);
                CharacterSelectScripts._isPlayer1 = false;
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