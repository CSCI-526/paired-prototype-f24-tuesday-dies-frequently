using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] TextMeshProUGUI expUI;
    [SerializeField] GameObject gameOverScreen;

    private Nexus nexus;
    private PlayerHealth playerHP;
    private PlayerLevels playerLevels;

    // Start is called before the first frame update
    void Start()
    {
        nexus = GameManager.Instance.Nexus.GetComponent<Nexus>();
        playerHP = GameManager.Instance.Player.GetComponent<PlayerHealth>();
        playerLevels = GameManager.Instance.Player.GetComponent<PlayerLevels>();
        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        UpdateWaveUI();
        UpdatePlayerXPUI();
    }
    
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }


    public void UpdateWaveUI()
    {
        if (nexus && playerHP)
        {
            scoreBoard.text = "Wave: " + GameManager.Instance.WaveManager.wave +
            "\r\nNexus: " + nexus.health + "/" + nexus.maxHealth +
            "\r\nHP: " + playerHP.currentHealth + "/" + playerHP.maxHealth;
        }
    }

    public void UpdatePlayerXPUI()
    {
        if (playerLevels)
        {
            expUI.text = "Player Level: " + playerLevels.currentLevel +
                "\r\nExp: " + playerLevels.currentXP + "/" + playerLevels.xpNeededForLevel;
        }
    }
}
