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
        private void Start()
        {
            this.StartTimer(3 ,PrincipalAttack );
        }
        private void PrincipalAttack()
        {
            StartCoroutine(PrincipalAttackCoroutine());
            //probably will use ObjectPool
           
        }
        
        private  IEnumerator PrincipalAttackCoroutine()
        {
            while (true)
            {
            EventManager.Instance.TriggerOnShootingEvent(true);
            yield return new WaitForSeconds(0.1f);
            InstantiateBullet();
            yield return new WaitForSeconds(0.5f);
            EventManager.Instance.TriggerOnShootingEvent(false);
            yield return new WaitForSeconds(0.5f);
            }
        }

        private void InstantiateBullet()
        {
            Instantiate(bulletPrefab,transform.position , Quaternion.Euler(transform.localScale.x,0,0) );
        }

        public void RightMouseButtonPressed(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                // The right mouse button is initially pressed
                Debug.Log("Right mouse button pressed");
                EventManager.Instance.TriggerOnThrowingEvent(true);
            }
            else if (context.canceled)
            {
                // The right mouse button is released
                Debug.Log("Right mouse button released");
                EventManager.Instance.TriggerOnThrowingEvent(false);
            }
        }
       
    }
    
}