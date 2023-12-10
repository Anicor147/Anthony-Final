using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Extensions
{
    public static class ExtensionMethods
    {
        public static void LoadScene(this MonoBehaviour monoBehaviour, string name, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene(name, loadSceneMode);
        }

        public static void UnloadScene(this MonoBehaviour monoBehaviour, string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }

        public static void StartTimer(this MonoBehaviour monoBehaviour, float duration, Action callBack)
        {
            monoBehaviour.StartCoroutine(TimerCoroutine(duration, callBack));
        }

        private static IEnumerator TimerCoroutine(float duration, Action callBack)
        {
            yield return new WaitForSeconds(duration);
            callBack?.Invoke();
        }
    }
}