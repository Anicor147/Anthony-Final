using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TurretScripts : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject turretPrefab;
    private Vector3 _mousePosition;
    private Camera _camera;
    private bool _rightIsPressed;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        //Subscribe to Event - Source PlayerAttack
        EventManager.Instance.OnThrowingChanged += value => _rightIsPressed = value;
    }
    
    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        
        if(!_rightIsPressed) return;
        InstantiateTurret();
    }

    private Vector3 GetCellCenter()
    {
        var cellPosition = grid.WorldToCell(_mousePosition);
        var cellCenter = grid.WorldToLocal(cellPosition);

        return cellCenter;
    }

    private void InstantiateTurret()
    {
        var cellCenter = GetCellCenter();
        Instantiate(turretPrefab, cellCenter, Quaternion.identity);
    }
}