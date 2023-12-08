using System;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.PlayerScripts
{
  public class CameraMovement : MonoBehaviour
  {
    private Vector3 _playerPosition;
    
    
    private void Start()
    {
      //Subscribe to Event - Source PlayerMovement
      EventManager.Instance.OnCharacterPosition += vector3 => _playerPosition = vector3;
    }

    private void OnDisable()
    {
      EventManager.Instance.OnCharacterPosition -= vector3 => _playerPosition = vector3;
    }

    private void Update()
    {
      //follow player
      transform.position = _playerPosition + new Vector3(0, 0, -1);
    }
  }
}
