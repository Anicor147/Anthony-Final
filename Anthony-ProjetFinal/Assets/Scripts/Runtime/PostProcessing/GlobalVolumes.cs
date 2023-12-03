using System;
using System.Collections;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Runtime.PostProcessing
{
    public class GlobalVolumes : MonoBehaviour
    {
        private Volume _volume;
        private Vignette _vignette;

        private float originalValue;
        private float maxValue = 1f;
        private bool effectStarted;

        private void Awake()
        {
            _volume = GetComponent<Volume>();
            _volume.profile.TryGet(out _vignette);
        }

        private void Start()
        {
            //Subscribe to Event Source PlayerController
            EventManager.Instance.OnHealthChanged += LowHealthPostProcessingEffect;
        }

        //Start or Stop Coroutine, do it one time
        private void LowHealthPostProcessingEffect(int health)
        {
            if (health <= 30 && !effectStarted)
            {
                StartCoroutine(PostProcessingCoroutine());
            }
            else if (health > 30)
            {
                StopCoroutine(PostProcessingCoroutine());
                effectStarted = false;
            }
        }

        //Lerp the intensity of vignette
        private IEnumerator PostProcessingCoroutine()
        {
            effectStarted = true;
            originalValue = _vignette.intensity.value;
            while (true)
            {
                _vignette.intensity.Override(Mathf.Lerp(originalValue, maxValue, 0.6f));
                yield return new WaitForSeconds(0.5f);
                _vignette.intensity.Override(Mathf.Lerp(maxValue, originalValue, 0.3f));
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}