using System;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Managers
{
    public class SceneController : MonoBehaviour
    {
        private void Awake()
        {
            if (GameObject.FindGameObjectWithTag("Player")== null)
            {
                GameManager.SceneToLoad = SceneManager.GetActiveScene().name;
                this.LoadScene("Main", LoadSceneMode.Single);
            }
        }
    }
}