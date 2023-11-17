using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private void Awake()
        {
            Instance = this;
            this.LoadScene("Level1" ,LoadSceneMode.Additive);
        }
        
    }
}