using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.Managers
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource audioSource;
        [SerializeField] private AudioClip audioMainMenu;
        [SerializeField] private AudioClip audioLevel1;
        [SerializeField] private AudioClip audioLevel2;
        [SerializeField] private AudioClip audioLevel3;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundEffectSlider;
        [SerializeField] private PlayerSelectionData playerSelectionData;
        private Scene _currentScene;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            _currentScene = SceneManager.GetActiveScene();
            if (_currentScene.name == "Main")
            {
                musicSlider.value = playerSelectionData.MusicSoundValue;
                audioSource.volume = musicSlider.value;
            }
            else if (_currentScene.name == "MainMenu")
            {
                musicSlider.value = playerSelectionData.MusicSoundValue;
                soundEffectSlider.value = playerSelectionData.SoundEffectValue;
                Debug.Log(playerSelectionData.SoundEffectValue);
                audioSource.volume = musicSlider.value;
            }

            ChangeAudioSourceClip();
        }

        private void ChangeAudioSourceClip()
        {
            if (_currentScene.name != "MainMenu")
            {
                switch (GameManager.CurrentScene)
                {
                    case "Level1":
                        audioSource.clip = audioLevel1;
                        break;
                    case "Level2":
                        audioSource.clip = audioLevel2;
                        break;
                    case "Level3":
                        audioSource.clip = audioLevel3;
                        break;
                }
            }
            else if (_currentScene.name == "MainMenu")
            {
                audioSource.clip = audioMainMenu;
            }

            audioSource.Play();
        }


        public void MusicVolumeChange(float value)
        {
            audioSource.volume = value;
            playerSelectionData.MusicSoundValue = value;
        }

        public void SoundEffectVolumeChange(float value)
        {
            playerSelectionData.SoundEffectValue = value;
        }
    }
}