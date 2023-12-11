using System.Collections;
using Runtime.Extensions;
using UnityEngine;

namespace Runtime.Managers
{
    public class Level2Manager : MonoBehaviour
    {
        [SerializeField] private GameObject cyberTigerPrefab;
        [SerializeField] private GameObject hopperPrefab;
        [SerializeField] private float cyberSpawnRate;
        [SerializeField] private float hopperSpawnRate;
        private float _radius = 20;
        private bool _loadScene;

        void Start()
        {
            this.StartTimer(1f, () => StartCoroutine(SpawnCyberEnemy()));
            this.StartTimer(1f, () => StartCoroutine(SpawnHopperEnemy()));

            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = transform.position;
        }

        private IEnumerator SpawnCyberEnemy()
        {
            while (true)
            {
                var insideUnitCircle = RandomPosition();
                Instantiate(cyberTigerPrefab, insideUnitCircle, Quaternion.identity, transform);
                yield return new WaitForSeconds(cyberSpawnRate);
            }
        }

        private IEnumerator SpawnHopperEnemy()
        {
            while (true)
            {
                var insideUnitCircle = RandomPosition();
                Instantiate(hopperPrefab, insideUnitCircle, Quaternion.identity, transform);
                yield return new WaitForSeconds(hopperSpawnRate);
            }
        }

        private Vector3 RandomPosition()
        {
            var insideUnitCircle = Random.insideUnitCircle.normalized * _radius;
            return insideUnitCircle;
        }
    }
}