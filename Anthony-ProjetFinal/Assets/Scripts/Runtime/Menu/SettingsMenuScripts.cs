using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuScripts : MonoBehaviour
{
    [SerializeField] private GameObject settingsGameObject;
    private bool _settingIsOpen;

    private void Update()
    {
        OpenCloseSetting(false);
    }


    //Open-Close player Setting Menu
    public void OpenCloseSetting( bool isPressed)
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_settingIsOpen)
        {
            Time.timeScale = 0;
            settingsGameObject.SetActive(true);
            _settingIsOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _settingIsOpen  || isPressed)
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
        this.LoadScene("MainMenu" , LoadSceneMode.Single);
    }

}
