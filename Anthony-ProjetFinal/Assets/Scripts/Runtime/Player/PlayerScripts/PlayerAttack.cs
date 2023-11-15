using System;
using System.Collections;
using Runtime.Extensions;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Player.PlayerScripts
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        private bool isThrowing = false;
        private bool isCoroutineRunning = false;
        private void Start()
        {
            //start timer
            this.StartTimer(3 ,() => StartCoroutine(PrincipalAttackCoroutine()) );
        }
        
        private  IEnumerator PrincipalAttackCoroutine()
        {
            if (isCoroutineRunning) yield break;
            isCoroutineRunning = true;
            
            while (!isThrowing )
            {
            EventManager.Instance.TriggerOnShootingEvent(true);
            yield return new WaitForSeconds(0.1f);
            InstantiateBullet();
            yield return new WaitForSeconds(0.5f);
            EventManager.Instance.TriggerOnShootingEvent(false);
            yield return new WaitForSeconds(0.5f);
            }
            isCoroutineRunning = false;
        }

        public void RightMouseButtonPressed(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                // The right mouse button is initially pressed
                isThrowing = true;
                StopCoroutine(PrincipalAttackCoroutine());
                EventManager.Instance.TriggerOnThrowingEvent(true);
            }
            else if (context.canceled)
            {
                // The right mouse button is released
                isThrowing = false;
                StartCoroutine(PrincipalAttackCoroutine());
                EventManager.Instance.TriggerOnThrowingEvent(false);
            }
        }

        private void InstantiateBullet()
        {
            Instantiate(bulletPrefab,transform.position , Quaternion.Euler(transform.localScale.x,0,0) );
        }
    }
    
}