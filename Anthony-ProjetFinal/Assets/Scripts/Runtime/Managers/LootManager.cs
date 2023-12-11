using UnityEngine;

namespace Runtime.Managers
{
    public class LootManager : MonoBehaviour
    {
        [SerializeField] private GameObject moneyPrefab;


        public void MoneyLoot(Vector3 position)
        {
            Instantiate(moneyPrefab, position, Quaternion.identity);
        }
    }
}