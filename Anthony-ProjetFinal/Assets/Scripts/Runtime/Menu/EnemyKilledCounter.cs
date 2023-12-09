using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKilledCounter : MonoBehaviour
{
   public static EnemyKilledCounter Instance { get; private set; }
   [SerializeField] private TMP_Text enemyCounterText;
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
