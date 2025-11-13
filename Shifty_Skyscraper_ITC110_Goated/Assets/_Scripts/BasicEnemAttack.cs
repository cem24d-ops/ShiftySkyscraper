using UnityEngine;

public class BasicEnemAttack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask playerLayers;
    public Transform player1;
    public Transform player2;
    public float nextAttackTime = 0f;
    public float attackRate = 1f;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (playerLayers == null)
        {
            Debug.LogWarning("Player Layers not assigned in BasicEnemAttack script.");
        }

        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        if (Time.time >= nextAttackTime)
        {
            if (distanceToPlayer1 <= attackRange || distanceToPlayer2 <= attackRange)
            {
                Attack();
            }
        }
    }
    
    public void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy Attacked Player! Dealt " + attackDamage + " damage.");
            }
        }
    }

    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
}
