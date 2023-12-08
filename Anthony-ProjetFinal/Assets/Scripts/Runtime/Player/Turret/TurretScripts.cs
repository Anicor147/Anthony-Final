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
    [SerializeField] private int _turretLimit;
    [SerializeField] private GameObject turretBulletPool;
    private Vector3 _mousePosition;
    private Camera _camera;
    private bool _rightIsPressed;
    private bool _canPlace = true;
    private int _numberOfTurret;
    private List<GameObject> turretList;

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
        turretList = new List<GameObject>();
        //Subscribe to Event - Source PlayerAttack
        EventManager.Instance.OnThrowingChanged += value => _rightIsPressed = value;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnThrowingChanged -= value => _rightIsPressed = value;
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        // make it only one at a time
        if (_rightIsPressed && _canPlace )
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
        turretList.Add(instantiatedTurret);
        
        if (_numberOfTurret > TurretLimit)
        {
            Destroy(turretList[0]); // Destroy the oldest turret
            turretList.RemoveAt(0); // Remove it from the list
        }
        CheckLocalScaleOfTurret(instantiatedTurret);
        StartCoroutine(PrincipalTurretAttackCoroutine(instantiatedTurret));
    }
    
    private IEnumerator PrincipalTurretAttackCoroutine(GameObject turret)
    {
        var turretTransform = turret.transform;
        var position = turretTransform.position;
        
        var bulletPosition = turretTransform.Find("BulletPosition");
        Quaternion bulletRotation = Quaternion.identity;
        
        if (turret.transform.localScale.x == -1)
        {
            bulletRotation = Quaternion.Euler(0, 0, 0); 
        }
        else if (turret.transform.localScale.x == 1)
        {
            bulletRotation = Quaternion.Euler(0, 180, 0); 
        }

        while (true)
        {
            if (turret == null && turretTransform == null) yield break; 
            yield return new WaitForSeconds(1f);
            Instantiate(turretBullet, bulletPosition.position, bulletRotation , turretBulletPool.transform );
            yield return new WaitForSeconds(1f);
            Instantiate(turretBullet, bulletPosition.position, bulletRotation , turretBulletPool.transform);
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