using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Runtime.Menu
{
    public class MainMenuScripts : MonoBehaviour
    {
        [SerializeField] private GameObject settingsCanvas;
        [SerializeField] private GameObject charactersCanvas;
        
        //Open Setting
        public void OpenSetting()
        {
            settingsCanvas.SetActive(true);
        }

        //Quit Game
        public void CloseGame()
        {
            Application.Quit();
        }

        //OpenCharacterSelection
        public void OpenCharacterSelectionMenu()
        {
            charactersCanvas.SetActive(true);
        }
    }
}
