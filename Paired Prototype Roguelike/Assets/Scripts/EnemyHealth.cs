using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public int maxHealth = 5;
    [SerializeField] public float invincibilityDuration = 0.01f;

    private int currentHealth;
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        GameManager.Instance.WaveManager.enemyCount++;
        GameManager.Instance.WaveManager.enemies.Add(this.gameObject);
        //Debug.Log(GameManager.Instance.WaveManager.enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (!isInvincible) // Only take damage if not currently invincible
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(InvincibilityCoroutine());
            }
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    public void Die()
    {
        GameManager.Instance.WaveManager.enemyCount--;
        GameManager.Instance.WaveManager.enemies.Remove(this.gameObject);

        //Debug.Log(GameManager.Instance.WaveManager.enemyCount);
        Destroy(gameObject);
    }
}
