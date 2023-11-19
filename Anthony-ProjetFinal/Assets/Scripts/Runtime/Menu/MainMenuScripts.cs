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
        
        //Close Setting
        public void CloseSetting()
        {
            settingsCanvas.SetActive(false);
        }

        //Quit Game
        public void CloseGame()
        {
            Application.Quit();
        }

        //Open CharacterSelection
        public void OpenCharacterSelectionMenu()
        {
            charactersCanvas.SetActive(true);
        }
        
        //Close CharacterSelection
        public void CloseCharacterSelectionMenu()
        {
            charactersCanvas.SetActive(false);
        }
    }
}
