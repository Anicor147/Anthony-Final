using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsParametersScript : MonoBehaviour
{
    [SerializeField] private Toggle _vignetteToggle;
    [SerializeField] private Toggle _filmGrainToggle;
    [SerializeField] private PlayerSelectionData _playerSelectionData;

    private bool _vignetteCheck;
    private bool _filmGrainCheck;

    private void Start()
    {
        _playerSelectionData.ResetSettings();
        _vignetteCheck = true;
        _filmGrainCheck = true;
        _playerSelectionData.VignetteIsActivated = _vignetteCheck;
        _playerSelectionData.FilmGrainIsActivated = _filmGrainCheck;
        Debug.Log("Default vignette value : "+_playerSelectionData.VignetteIsActivated);
        Debug.Log("Default filmGrain value : "+_playerSelectionData.FilmGrainIsActivated);
    }

    public void VignetteSetValue()
    {
        _vignetteCheck = _vignetteToggle.isOn;
        _playerSelectionData.VignetteIsActivated = _vignetteCheck;
        Debug.Log("Set vignette value : "+_playerSelectionData.VignetteIsActivated);
    }

    public void FilmGrainSetValue()
    {
        _filmGrainCheck = _filmGrainToggle.isOn;
        _playerSelectionData.FilmGrainIsActivated = _filmGrainCheck;
        Debug.Log("Set filmGrain value : "+_playerSelectionData.FilmGrainIsActivated);
    }

}