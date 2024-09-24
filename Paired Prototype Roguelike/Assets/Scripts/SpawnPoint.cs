using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] protected bool spawnAtStart = true;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    public float spawnRange = 5.0f;

    void Start()
    {
        GameManager.Instance.WaveManager.spawnPoints.Add(this);
        if(spawnAtStart)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy(float delay = 0.0f)
    {
        if(enemyPrefabs.Count > 0)
        {
            StartCoroutine(DelayedSpawn(delay));
        }
        else
        {
            Debug.Log("Error: spawning pool not populated");
        }
    }

    public void SpawnEnemyOfType(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = transform.position;
        // enemy.GetComponent<EnemyMove>().SetTarget(GameManager.Instance.Player);
    }

    IEnumerator DelayedSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject enemy = Instantiate(enemyToSpawn); 
        enemy.transform.position = new Vector3(transform.position.x+Random.Range(-1*spawnRange, spawnRange), transform.position.y, transform.position.z+Random.Range(-1*spawnRange, spawnRange));
    }
}
