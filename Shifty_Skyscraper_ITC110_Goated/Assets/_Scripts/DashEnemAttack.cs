using UnityEngine;

public class DashEnemAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform attackPoint;
    public LayerMask playerLayers;
    public Transform player1;
    public Transform player2;
    public Transform targetPlayer;
    public float nextAttackTime = 0f;
    public float attackRate = 1f;
    public float attackRange = 0.5f;
    public float dashDetectRange = 5f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public bool dashForward = true;
    float xDirection;
    Canvas gameCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        // Check distance to both players
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        if (targetPlayer != null && Vector2.Distance(transform.position, targetPlayer.position) <= attackRange)
        {
            xDirection = (targetPlayer.position - transform.position).x;
            if (xDirection > 0)
            {
                dashForward = true;
            }

            else if (xDirection < 0)
            {
                dashForward = false;
            }

            // If either player is within attack range and cooldown has passed, attack
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("Dash Enemy is attacking!");
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
            if (dashForward)
            {
                transform.Translate(Vector2.right * dashSpeed * dashDuration);
                gameCanvas.GetComponent<GameManager>().LoseLife();
            }
            else
            {
                transform.Translate(Vector2.left * dashSpeed * dashDuration);
                gameCanvas.GetComponent<GameManager>().LoseLife();
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
