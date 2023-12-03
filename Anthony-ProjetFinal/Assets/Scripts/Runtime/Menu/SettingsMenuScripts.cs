using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using Runtime.PostProcessing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject settingsGameObject;
    [SerializeField] private Toggle vignetteToggle;
    [SerializeField] private Toggle secondToggle;

    [FormerlySerializedAs("postProcessingEffect")] [SerializeField]
    private GameObject postProcessingVignetteEffect;

    private bool _settingIsOpen;


    private void Start()
    {
        if (SettingsParametersScript.Instance != null)
        {
            vignetteToggle.isOn = SettingsParametersScript.Instance.VignetteCheck;
        }
    }

    private void Update()
    {
        OpenCloseSetting(false);
    }

    //Set active or not Vignette PPE
    public void VignetteValue()
    {
        postProcessingVignetteEffect.SetActive(vignetteToggle.isOn);
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