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
    Canvas gameCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        // Check distance to both players
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        // If either player is within attack range and cooldown has passed, attack
        if (Time.time >= nextAttackTime)
        {
            //Debug.Log("Enemy is checking for attack opportunity.");

            // Check if either player is within attack range
            if (distanceToPlayer1 <= attackRange || distanceToPlayer2 <= attackRange)
            {
                //Debug.Log("Enemy is attacking!");
                nextAttackTime = Time.time + 1f / attackRate;
                Attack();
                
            }
        }
    }
    
    public void Attack()
    {
        // Detect players in range of attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        gameCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        // Damage players
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Player hit: " + player.name);
            gameCanvas.GetComponent<GameManager>().LoseLife();
            break;
        }
    }

    void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
}
