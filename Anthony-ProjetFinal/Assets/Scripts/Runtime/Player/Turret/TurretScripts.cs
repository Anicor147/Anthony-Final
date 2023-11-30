using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using Runtime.Managers;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TurretScripts : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private GameObject playerPosition;
    [SerializeField] private GameObject turretBullet;
    private Vector3 _mousePosition;
    private Camera _camera;
    private bool _rightIsPressed;
    private bool _canPlace = true;
    private int _numberOfTurret;
    [SerializeField] private int _turretLimit;

    public int TurretLimit
    {
        get => _turretLimit;
        set => _turretLimit = value;
    }

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
        if (_rightIsPressed && _canPlace && TurretLimit != _numberOfTurret)
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

    //Instantiate Turret
    private void InstantiateTurret()
    {
        var cellCenter = GetCellCenter();
        _canPlace = false;
        var instantiatedTurret = Instantiate(turretPrefab, cellCenter, Quaternion.identity);
        _numberOfTurret++;
        CheckLocalScaleOfTurret(instantiatedTurret);
        StartCoroutine(PrincipalTurretAttackCoroutine(instantiatedTurret));
    }
    
    private IEnumerator PrincipalTurretAttackCoroutine(GameObject turret)
    {
        var position = turret.transform.position;
        Quaternion bulletRotation = Quaternion.identity;
        
        if (turret.transform.localScale.x == -1)
        {
            Debug.Log("should be right");
            bulletRotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (turret.transform.localScale.x == 1)
        {
            Debug.Log("should be left ");
            bulletRotation = Quaternion.Euler(0, 180, 0); 
        }

        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(turretBullet, position, bulletRotation);
            yield return new WaitForSeconds(1f);
            Instantiate(turretBullet, position, bulletRotation);
            TurretBulletsScript.Instance.Scale(transform);
            yield return new WaitForSeconds(0.5f);
        }
    }

    
    //Check Local Scale
    private void CheckLocalScaleOfTurret(GameObject turret)
    {
        if (turret.transform.position.x > playerPosition.transform.position.x)
        {
            turret.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (turret.transform.position.x < playerPosition.transform.position.x)
        {
            turret.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}