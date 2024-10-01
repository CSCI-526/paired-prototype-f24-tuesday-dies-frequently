using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.Nexus = this.gameObject;
        health = maxHealth;
    }
    public void TakeDamage(int amount = 1)
    {
        health -= amount;
        GameManager.Instance.UIManager.UpdateUI();
        if (health < 0)
        { 
            GameManager.Instance.TriggerGameOver();
            gameObject.SetActive(false);
        }
    }

}
