using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnem : MonoBehaviour
{

    public int health;
    public float speed;
    public bool isChasing = false;
    public Transform player1;
    public Transform player2;
    public float detectionRange = 10f;
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

        if (isChasing)
        {
            Transform targetPlayer = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

            RangedEnemAttack rangedAttack = GetComponent<RangedEnemAttack>();
            rangedAttack.targetPlayer = targetPlayer;
            if (rangedAttack != null)
            {
                if (targetPlayer.position.x > transform.position.x)
                {
                    rangedAttack.fireForward = true;
                }
                else
                {
                    rangedAttack.fireForward = false;
                }
            }
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

