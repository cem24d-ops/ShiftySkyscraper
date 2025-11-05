using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public KeyCode attackKey;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;
    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {

            if (Input.GetKeyDown(attackKey))
            {
                // Attack code here
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enem>().TakeDamage(damage);
                }
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
