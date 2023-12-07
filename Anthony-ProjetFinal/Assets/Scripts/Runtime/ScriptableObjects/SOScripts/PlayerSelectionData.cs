using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSelectionData", menuName = "SO/PlayerSelectionData", order = 3)]
public class PlayerSelectionData : ScriptableObject
{
    private bool isPlayer1Selected;
   private bool isPlayer2Selected;
    private bool vignetteIsActivated = true;
    private bool filmGrainIsActivated =true;

   private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    
    public bool IsPlayer1Selected
    {
        get => isPlayer1Selected;
        set => isPlayer1Selected = value;
    }

    public bool IsPlayer2Selected
    {
        get => isPlayer2Selected;
        set => isPlayer2Selected = value;
    }

    public bool VignetteIsActivated
    {
        get => vignetteIsActivated;
        set => vignetteIsActivated = value;
    }

    public bool FilmGrainIsActivated
    {
        get => filmGrainIsActivated;
        set => filmGrainIsActivated = value;
    }

    public void ResetValue()
    {
        IsPlayer1Selected = false;
        IsPlayer2Selected = false;
    }

    public void ResetSettings()
    {
        VignetteIsActivated = false;
        FilmGrainIsActivated = false;
    }
}