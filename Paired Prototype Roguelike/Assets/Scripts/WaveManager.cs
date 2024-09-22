using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] protected int maxEnemies = 10;
    [SerializeField] protected float spawnInterval = 5.0f;
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] int enemyCount = 0;
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();


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
}
