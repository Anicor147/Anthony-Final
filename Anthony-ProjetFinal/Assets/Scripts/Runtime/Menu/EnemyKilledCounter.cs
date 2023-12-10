using TMPro;
using UnityEngine;

public class EnemyKilledCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyCounterText;
    public static EnemyKilledCounter Instance { get; private set; }
    private int enemyCounter;

    public int EnemyCounter
    {
        get => enemyCounter;
        set => enemyCounter = value;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        enemyCounterText.text = enemyCounter.ToString();
    }
}