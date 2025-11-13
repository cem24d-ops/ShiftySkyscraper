using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int maxHealth = 5;

    void Update()
    {
        if (maxHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player Hit! Remaining Health: " + maxHealth);
        if (maxHealth <= 0)
        {
            Debug.Log("Player Defeated! Game Over!");
            return;
        }
        maxHealth -= damage;
    }

    void Die()
    {
        Debug.Log("Player Defeated! Game Over!");
        Destroy(gameObject);
    }
}
