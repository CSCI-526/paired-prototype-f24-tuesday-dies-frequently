using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public WaveManager WaveManager { get; private set; }
    public GameObject Player {  get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        Instance.Player = GameObject.FindGameObjectWithTag("Player");
        Instance.WaveManager = GetComponent<WaveManager>();
    }

    void Start()
    {
    }



}
