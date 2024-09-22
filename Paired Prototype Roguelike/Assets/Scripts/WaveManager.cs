using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance {  get; private set; }

    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float spawnInterval = 5.0f;
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] int enemyCount = 0;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject spawnpoint in spawnPoints)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnInitialWave()
    {
        foreach (GameObject spawnpoint in spawnPoints)
        {

        }
    }
}
