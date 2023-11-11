using System;
using System.Collections;
using UnityEngine;

namespace Extensions
{
    public static class ExtensionMethods 
    {
        public static void StartTimer(this MonoBehaviour monoBehaviour , float duration, Action callBack) 
        { 
            monoBehaviour.StartCoroutine(TimerCoroutine(duration , callBack));
        }
        private static IEnumerator TimerCoroutine(float duration, Action callBack)
        {
            yield return new WaitForSeconds(duration);
            callBack?.Invoke();
        }
    }
}