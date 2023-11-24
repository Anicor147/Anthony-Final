using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
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
    private bool _canPlace = true;

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

        // make it only one at a time
        if (_rightIsPressed && _canPlace)
        {
            InstantiateTurret();
            this.StartTimer(3f, () => _canPlace = true);
        }
    }

    private Vector3 GetCellCenter()
    {
        // get position from world
        var cellPosition = grid.WorldToCell(_mousePosition);
        //get center of cell
        var cellCenter = grid.GetCellCenterWorld(cellPosition);

        return cellCenter;
    }

    private void InstantiateTurret()
    {
        var cellCenter = GetCellCenter();
        _canPlace = false;
        Instantiate(turretPrefab, cellCenter, Quaternion.identity);
    }
}