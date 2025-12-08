using UnityEngine;
using System.Collections;

public class DashEnemAttack : MonoBehaviour
{
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

    void Start()
    {
        gameCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Update()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        targetPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;

        if (Vector2.Distance(transform.position, targetPlayer.position) <= dashDetectRange)
        {
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + 1f / attackRate;
                StartCoroutine(DashAttack());
            }
        }
    }

    IEnumerator DashAttack()
    {
        // Determine direction
        xDirection = (targetPlayer.position - transform.position).x;

        dashForward = xDirection > 0;

        float timer = 0f;

        while (timer < dashDuration)
        {
            transform.Translate((dashForward ? Vector2.right : Vector2.left) * dashSpeed * Time.deltaTime);

            // Damage while dashing
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            foreach (Collider2D p in hitPlayers)
            {
                gameCanvas.GetComponent<GameManager>().LoseLife();
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}