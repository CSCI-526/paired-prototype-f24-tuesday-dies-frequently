using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] GameObject gameOverScreen;

    private Nexus nexus;
    private PlayerHealth playerHP;

    // Start is called before the first frame update
    void Start()
    {
        nexus = GameManager.Instance.Nexus.GetComponent<Nexus>();
        playerHP = GameManager.Instance.Player.GetComponent<PlayerHealth>();
        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        if(nexus && playerHP)
        {
            scoreBoard.text = "Wave: " + GameManager.Instance.WaveManager.wave +
            "\r\nNexus: " + nexus.health + "/" + nexus.maxHealth +
            "\r\nHP: " + playerHP.currentHealth + "/" + playerHP.maxHealth;
        }
    }
    
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
