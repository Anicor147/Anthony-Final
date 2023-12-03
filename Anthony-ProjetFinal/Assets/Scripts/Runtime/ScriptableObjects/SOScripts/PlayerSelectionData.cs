using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSelectionData", menuName = "SO/PlayerSelectionData", order = 3)]
public class PlayerSelectionData : ScriptableObject
{
    public bool IsPlayer1Selected = false;
    public bool IsPlayer2Selected = false;

    public void ResetValue()
    {
        IsPlayer1Selected = false;
        IsPlayer2Selected = false;
    }
}