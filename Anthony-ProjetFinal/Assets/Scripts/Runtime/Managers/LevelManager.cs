using System.Collections;
using Runtime.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject cyberTigerPrefab;
        [SerializeField] private float spawnRate;
        private float _radius = 20;
        private bool _loadScene;

        void Start()
        {
            this.StartTimer(1f, () => StartCoroutine(SpawnEnemy()));

            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = transform.position;
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                var insideUnitCircle = RandomPosition();
                Instantiate(cyberTigerPrefab, insideUnitCircle, Quaternion.identity, transform);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private Vector3 RandomPosition()
        {
            var insideUnitCircle = Random.insideUnitCircle.normalized * _radius;
            return insideUnitCircle;
        }
    }
}