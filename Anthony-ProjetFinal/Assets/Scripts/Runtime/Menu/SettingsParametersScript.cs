using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsParametersScript : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    public static SettingsParametersScript Instance { get; private set; }

    private bool _vignetteCheck;
    public bool VignetteCheck { get; set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        VignetteCheck = true;
    }

    public void VignetteValue()
    {
        VignetteCheck = _toggle.isOn;
    }
}