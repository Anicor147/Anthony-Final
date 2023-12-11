using UnityEngine;

namespace Runtime.Menu
{
    public class CharacterSelectScripts : MonoBehaviour
    {
        [SerializeField] private PlayerSelectionData playerSelectionData;

        [SerializeField] private GameObject levelSelectionMenu;


        private void Start()
        {
            playerSelectionData.ResetValue();
        }

        //Choose Character1
        public void SelectPlayer1()
        {
            playerSelectionData.IsPlayer1Selected = true;
            playerSelectionData.IsPlayer2Selected = false;
            levelSelectionMenu.SetActive(true);
        }

        //Choose Character2
        public void SelectPlayer2()
        {
            playerSelectionData.IsPlayer1Selected = false;
            playerSelectionData.IsPlayer2Selected = true;
            levelSelectionMenu.SetActive(true);
        }
    }
}