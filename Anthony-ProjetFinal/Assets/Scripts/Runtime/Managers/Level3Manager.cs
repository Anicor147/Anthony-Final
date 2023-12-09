using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] private GameObject cyberTigerPrefab;
    [SerializeField] private GameObject hopperPrefab;
    [SerializeField] private GameObject waspPrefab;
    [SerializeField] private float cyberSpawnRate;
    [SerializeField] private float hopperSpawnRate;
    [SerializeField] private float waspSpawnRate;
    private float _radius = 20;
    private bool _loadScene;
    
    void Start()
    {
      var player =  GameObject.FindGameObjectWithTag("Player");
      player.transform.position = transform.position;
        
        this.StartTimer(1f, () => StartCoroutine(SpawnCyberEnemy()));
        this.StartTimer(1f, () => StartCoroutine(SpawnHopperEnemy()));
        this.StartTimer(1f, () => StartCoroutine(SpawnWaspEnemy()));
    }
        
    private IEnumerator SpawnCyberEnemy()
    {
        while (true)
        {
            var insideUnitCircle = RandomPosition();
            Instantiate(cyberTigerPrefab, insideUnitCircle, Quaternion.identity , transform);
            yield return new WaitForSeconds(cyberSpawnRate);
        }
    }
    
    private IEnumerator SpawnHopperEnemy()
    {
        while (true)
        {
            var insideUnitCircle = RandomPosition();
            Instantiate(hopperPrefab, insideUnitCircle, Quaternion.identity , transform);
            yield return new WaitForSeconds(hopperSpawnRate);
        }
    }
    private IEnumerator SpawnWaspEnemy()
    {
        while (true)
        {
            var insideUnitCircle = RandomPosition();
            Instantiate(waspPrefab, insideUnitCircle, Quaternion.identity , transform);
            yield return new WaitForSeconds(waspSpawnRate);
        }
    }

    private Vector3 RandomPosition()
    {
        var insideUnitCircle = Random.insideUnitCircle.normalized * _radius;
        return insideUnitCircle;
    }
}
