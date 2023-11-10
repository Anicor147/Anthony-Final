using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  [SerializeField] private GameObject playerObject;
  
  private void Update()
  {
    transform.position = playerObject.transform.position + new Vector3(0, 0, -1);
  }
}
