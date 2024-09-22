using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float spawnInterval = 5.0f;

    [SerializeField] public int enemyCount = 0;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

    [SerializeField] public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private void Awake()
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        //SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 0)
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        foreach (SpawnPoint sp in spawnPoints)
        {
            sp.SpawnEnemy();
        }
    }
}
