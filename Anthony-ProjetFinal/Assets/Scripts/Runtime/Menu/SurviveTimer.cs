using Runtime.Managers;
using TMPro;
using UnityEngine;

namespace Runtime.Menu
{
    public class SurviveTimer : MonoBehaviour
    {
        public static SurviveTimer Instance { get; private set; }
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text timerTextGameOver;
        private float currentTime;
        private bool playerIsDead;

        public float CurrentTime
        {
            get => currentTime;
            set => currentTime = value;
        }

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            EventManager.Instance.OnPlayerDead += value => playerIsDead = value;
            currentTime = 0;
        }

        void Update()
        {
            if (playerIsDead) return;
            CurrentTime += Time.deltaTime;
            timerText.text = CurrentTime.ToString("N0");
            timerTextGameOver.text = CurrentTime.ToString("N0");
        }
    }
}