 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public float maxHealth = 5;
    [SerializeField] public float invincibilityDuration = 0.01f;
    [SerializeField] public GameObject exp;

    [SerializeField] public float xpDropRate = 0.5f;  

    private float currentHealth;
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

    public void TakeDamage(float damage)
    {
        if (!isInvincible) // Only take damage if not currently invincible
        {
            currentHealth-= damage;
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
        DropExp();
        //Debug.Log(GameManager.Instance.WaveManager.enemyCount);
        Destroy(gameObject);
    }

    public void DropExp(){
        if (Random.Range(0.0f, 1.0f) >= xpDropRate){
            GameObject xp = Instantiate(exp);
            xp.transform.position = transform.position;
        }
    }
}
