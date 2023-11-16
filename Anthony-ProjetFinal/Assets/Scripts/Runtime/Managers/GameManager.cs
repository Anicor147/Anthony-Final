using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Runtime.Enemies;
using Runtime.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public List<GameObject> _enemyList;
        [SerializeField] private float enemyCount;
        [SerializeField]private GameObject cyberTigerPrefab;
        private float _radius = 20;
        private bool loadedScene2 = false;
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
            SceneTransition();
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
        
        private void SceneTransition()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(sceneIndex);
            if (sceneIndex == 1)
            {
                if (_enemyList.Count == 0 && !loadedScene2)
                {
                    this.LoadScene("Level1" , LoadSceneMode.Additive);
                    loadedScene2 = true;
                }
            }
            else if (sceneIndex == 2 && Input.GetKeyDown(KeyCode.Space) )
            {
                Debug.Log($"LEVEL 1 ");
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(2);
            }
        }



    }
}