using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Runtime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }
    
        [HideInInspector] public List<GameObject> _enemyList;
        [SerializeField] private float enemyCount;
        [SerializeField]private GameObject cyberTigerPrefab;
        private float _radius = 20;
        private bool _loadScene;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            _enemyList = new List<GameObject>();
            AddGameObjectOnList();
            this.StartTimer(1f, () => StartCoroutine(SpawnEnemy()));
        }

        private void Update()
        {
            ZoneComplete();
        }

        void AddGameObjectOnList()
        {
            for (int i = 0; i < enemyCount; i++)
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
        
        private void ZoneComplete()
        {
            if (_enemyList.Count <= 0 && !_loadScene)
            {
                this.LoadScene("Level2" , LoadSceneMode.Additive);
                _loadScene = true;
            }
        }
    }
}
