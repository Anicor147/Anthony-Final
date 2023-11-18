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
        
        public void OpenSetting()
        {
            settingsCanvas.SetActive(true);
        }

        public void CloseGame()
        {
            Application.Quit();
        }

        public void OpenCharacterSelectionMenu()
        {
            charactersCanvas.SetActive(true);
        }
    }
}
