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
    public bool fireForward;
    public float bulletForce = 1500.0f;
    public bool inFireMode = false;
    public KeyCode switchModeKey;
    public GameObject bullet;
    public GameObject firePoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchModeKey))
        {
            if (inFireMode)
            {
                inFireMode = false;
            }
            else
            {
                inFireMode = true;
            }
        }

        if (!inFireMode)
        {
            if (timeBetweenAttack <= 0)
            {

                if (Input.GetKeyDown(attackKey))
                {
                    MeleeAttack();
                    timeBetweenAttack = startTimeBetweenAttack;
                }
            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
        else if (inFireMode)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > 0)
            {
                fireForward = true;
            }
            else if (horizontalInput < 0)
            {
                fireForward = false;
            }

            if (Input.GetKeyDown(attackKey))
            {
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        // Bullet instantiate at the position of GameObject
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

        // get Rigidbody2D component of instantiated Bullet
        Rigidbody2D tempRigidBody = newBullet.GetComponent<Rigidbody2D>();

        // push the Bullet forward by amount bulletForce
        if (fireForward)
        {
            // fireForward is fire to the right
            tempRigidBody.AddForce(transform.right * bulletForce);
        }
        else
        {
            // fire left, a.k.a. "negative right"
            tempRigidBody.AddForce(-transform.right * bulletForce);
        }

        // basic Clean Up, set Bullets to self destruct after 2 seconds
        Destroy(newBullet, 2.0f);
    }
    
    void MeleeAttack()
    {
        // Melee attack code here
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enem>().TakeDamage(damage);
        }

        // Also damage Ranged Enemies
        Collider2D[] rangedEnemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int j = 0; j < rangedEnemiesToDamage.Length; j++)
        {
            rangedEnemiesToDamage[j].GetComponent<RangedEnem>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
