using Runtime.Player.PlayerScripts;
using UnityEngine;

namespace Runtime.Items
{
    public class MoneyScript : MonoBehaviour
    {
        private int _moneyValue = 10;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().IncreaseMoney(_moneyValue);
                Destroy(gameObject);
            }
        }
    }
}