using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] protected bool spawnAtStart = true;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

    void Start()
    {
        if(spawnAtStart)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if(enemyPrefabs.Count > 0)
        {
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(enemyToSpawn);
        }
        else
        {
            Debug.Log("Error: spawning pool not populated");
        }
    }

    public void SpawnEnemyOfType(GameObject enemy)
    {
        Instantiate(enemy);
    }
}
