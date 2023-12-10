using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Runtime.Managers
{
    public class SoundEffectManager : MonoBehaviour
    {
        public static SoundEffectManager Instance { get; private set; }
        private AudioSource _audioSource;
        [SerializeField] private AudioClip beamAudioClip;

        [FormerlySerializedAs("ExplosionAudioClip")] [SerializeField]
        private AudioClip explosionAudioClip;

        [SerializeField] private Slider soundEffectSlider;
        [SerializeField] private PlayerSelectionData playerSelectionData;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            soundEffectSlider.value = playerSelectionData.SoundEffectValue;
            _audioSource.volume = soundEffectSlider.value;
        }

        public void PlayBeamSound()
        {
            _audioSource.PlayOneShot(beamAudioClip);
        }

        public void PlayExplosionSound()
        {
            _audioSource.PlayOneShot(explosionAudioClip);
        }

        public void SoundEffectVolumeChange(float value)
        {
            _audioSource.volume = value;
            playerSelectionData.SoundEffectValue = value;
        }
    }
}