using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Runtime.Enemies;
using Runtime.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        internal static string SceneToLoad = "Level1";
        internal static string CurrentScene = null;
        private void Awake()
        {
            Instance = this;
            CurrentScene = SceneToLoad;
            this.LoadScene(SceneToLoad ,LoadSceneMode.Additive);
        }
        
        internal static void LoadScene(string nexScene)
        {
            SceneManager.LoadScene(nexScene, LoadSceneMode.Additive);
            if (CurrentScene != null)
            {
                SceneManager.UnloadSceneAsync(CurrentScene);
            }
            CurrentScene = nexScene;
        }
    }
}