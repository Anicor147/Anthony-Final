using System;
using System.Collections;
using Extensions;
using UnityEngine;

namespace Player
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
            //Instantiate(bulletPrefab,transform.position , Quaternion.identity );
        }
        
        private static IEnumerator PrincipalAttackCoroutine()
        {
            while (true)
            {
            EventManager.Instance.TriggerOnShootingEvent(true);
            yield return new WaitForSeconds(1f);
            EventManager.Instance.TriggerOnShootingEvent(false);
            yield return new WaitForSeconds(3f);
            }
        }
        
    }
    
}