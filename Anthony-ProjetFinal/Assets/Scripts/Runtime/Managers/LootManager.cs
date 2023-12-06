using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;


    public void MoneyLoot(Vector3 position)
    {
        Instantiate(moneyPrefab, position, Quaternion.identity);
    }
}
