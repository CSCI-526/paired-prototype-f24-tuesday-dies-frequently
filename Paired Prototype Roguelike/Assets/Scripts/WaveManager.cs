using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float waveInterval = 5.0f;
    [SerializeField] protected float maxSpawnDelay = 2.0f;

    [SerializeField] public int enemyCount = 0;
    [SerializeField] public int wave = 0;
    [SerializeField] public float difficulty = 1.2f;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    float timeSinceLastWave;
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
        if(enemyCount <= 0 && timeSinceLastWave > waveInterval)
        {
            SpawnWave();
            timeSinceLastWave = 0.0f;
        }
        timeSinceLastWave += Time.deltaTime;
    }

    void SpawnWave()
    {
        ++wave;
        foreach (SpawnPoint sp in spawnPoints)
        {
            sp.SpawnEnemy(Random.Range(0.0f, maxSpawnDelay), wave, difficulty);
            // sp.SpawnEnemy(Random.Range(0.0f, maxSpawnDelay));
        }
        GameManager.Instance.UIManager.UpdateUI();
    }
}
