using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float spawnInterval = 5.0f;
    [SerializeField] List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    [SerializeField] public static int enemyCount = 0;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

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
        
    }

    void SpawnWave()
    {
        foreach (SpawnPoint sp in spawnPoints)
        {
            sp.SpawnEnemy();
        }
    }
}
