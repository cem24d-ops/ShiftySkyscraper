using UnityEngine;

public class RangedEnemAttack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask playerLayers;
    public Transform player1;
    public Transform player2;
    public Transform targetPlayer;
    public float nextAttackTime = 0f;
    public float attackRate = 1f;
    public float attackRange = 0.5f;
    public GameObject bulletPrefab;
    public bool fireForward = true;
    float xDirection;

    // Update is called once per frame
    void Update()
    {
        // Check distance to both players
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        // If either player is within attack range and cooldown has passed, attack
        if (Time.time >= nextAttackTime)
        {
            Debug.Log("Ranged Enemy is checking for attack opportunity.");

            // Check if either player is within attack range
            if (targetPlayer != null && Vector2.Distance(transform.position, targetPlayer.position) <= attackRange)
            {
                xDirection = (targetPlayer.position - transform.position).x;
                if (xDirection > 0)
                {
                    fireForward = true;
                }
                else if (xDirection < 0)
                {
                    fireForward = false;
                }

                Debug.Log("Ranged Enemy is attacking!");
                nextAttackTime = Time.time + 1f / attackRate;
                Attack();
                
            }
        }
    }
    public void Attack()
    {
        GameObject projectile = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation) as GameObject;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        // Shoot projectile towards players
        if (fireForward)
        {
            rb.AddForce(attackPoint.right * 1000f);
        }
        else
        {
            rb.AddForce(-attackPoint.right * 1000f);
        }   
    }
}
