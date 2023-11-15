using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Enemies;
using Runtime.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public List<GameObject> _enemyList;
        [SerializeField]private GameObject cyberTigerPrefab;
        private float _radius = 20;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            _enemyList = new List<GameObject>();
            AddGameObjectOnList();
            this.StartTimer(1f, () => StartCoroutine(SpawnEnemy()));
        }

        private void Update()
        {
            Debug.Log(_enemyList.Count);
        }

        void AddGameObjectOnList()
        {
            for (int i = 0; i < 100; i++)
            {
                 cyberTigerPrefab = Instantiate(cyberTigerPrefab, Vector3.zero, Quaternion.identity);
                 cyberTigerPrefab.SetActive(false);
                _enemyList.Add(cyberTigerPrefab);
            }
        }

        private IEnumerator SpawnEnemy()
        {
            foreach (var enemy in _enemyList)
            {
                var insideUnitCircle = Random.insideUnitCircle.normalized * _radius;
                enemy.transform.position = new Vector3(insideUnitCircle.x ,insideUnitCircle.y );
                enemy.SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
        }






    }
}