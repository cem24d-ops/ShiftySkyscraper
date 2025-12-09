using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnem : MonoBehaviour
{

    public int health;
    public float speed;
    public bool isChasing = false;
    public Transform player1;
    public Transform player2;
    public float detectionRange = 10f;
    public bool isDashing = false;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);

        bool player1InRange = distanceToPlayer1 <= detectionRange;
        bool player2InRange = distanceToPlayer2 <= detectionRange;

        if (player1InRange || player2InRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing && !isDashing)
        {
            Transform targetPlayer = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;

            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

            DashEnemAttack dashAttack = GetComponent<DashEnemAttack>();
            dashAttack.targetPlayer = targetPlayer;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy Hit! Remaining Health: " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Defeated!");
        }
    }
}
