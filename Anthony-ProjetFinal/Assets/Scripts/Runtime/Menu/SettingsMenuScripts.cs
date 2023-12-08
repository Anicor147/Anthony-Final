using Runtime.Extensions;
using Runtime.Managers;
using Runtime.Player.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject settingsGameObject;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Toggle vignetteToggle;
    [SerializeField] private Toggle filmGrainToggle;
    [SerializeField] private PlayerSelectionData _playerSelectionData;
    [SerializeField] private GameObject postProcessingVignetteEffect;
    [SerializeField] private GameObject postProcessingFilmGrainEffect;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text moneyCounterText;
    [SerializeField] private TMP_Text moneyGameOverCounterText;
    private bool _settingIsOpen;
    private int _moneyCounter;
    private bool _playerIsDead;
    private bool _eventIsHandled;
    private PlayerController _playerController;


    private void Start()
    {
        vignetteToggle.isOn = _playerSelectionData.VignetteIsActivated;
        filmGrainToggle.isOn = _playerSelectionData.FilmGrainIsActivated;
        postProcessingVignetteEffect.SetActive(_playerSelectionData.VignetteIsActivated);
        postProcessingFilmGrainEffect.SetActive(_playerSelectionData.FilmGrainIsActivated);
        _playerController = PlayerController.Instance;
        healthSlider.value = _playerController.CurrentHealth;

        EventManager.Instance.OnHealthChanged += UpdateHealthBar;
        EventManager.Instance.OnMoneyChanged += UpdateMoneyCounter;
        EventManager.Instance.OnPlayerDead += value => _playerIsDead = value;
    }

    private void Update()
    {
        OpenCloseSetting(false);

        if (_playerIsDead && !_eventIsHandled)
        {
            gameOverCanvas.SetActive(true);
            _eventIsHandled = true;
            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.OnHealthChanged -= UpdateHealthBar;
        EventManager.Instance.OnMoneyChanged -= UpdateMoneyCounter;
        EventManager.Instance.OnPlayerDead += value => _playerIsDead = value;
    }

    private void UpdateHealthBar(int value)
    {
        healthSlider.value = value;
        Debug.Log($"HealthBar Slider value = {healthSlider.value}");
    }


    private void UpdateMoneyCounter(int value)
    {
        moneyCounterText.text = value.ToString();
        moneyGameOverCounterText.text = moneyCounterText.text;
    }

    //Set active or not Vignette PPE
    public void VignetteValue()
    {
        postProcessingVignetteEffect.SetActive(vignetteToggle.isOn);
    }

    public void FilmGrainValue()
    {
        postProcessingFilmGrainEffect.SetActive(filmGrainToggle.isOn);
    }

    //Open-Close player Setting Menu
    public void OpenCloseSetting(bool isPressed)
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_settingIsOpen)
        {
            Time.timeScale = 0;
            settingsGameObject.SetActive(true);
            _settingIsOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _settingIsOpen || isPressed)
        {
            Time.timeScale = 1;
            settingsGameObject.SetActive(false);
            _settingIsOpen = false;
        }
    }

    //Goes back to Main Menu
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        this.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}