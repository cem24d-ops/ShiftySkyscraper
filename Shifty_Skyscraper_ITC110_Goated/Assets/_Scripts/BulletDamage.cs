using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enem enem = other.GetComponent<Enem>();
            if (enem != null)
            {
                enem.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("RangedEnem"))
        {
            RangedEnem rangedEnem = other.GetComponent<RangedEnem>();
            if (rangedEnem != null)
            {
                rangedEnem.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("DashEnem"))
        {
            DashEnem dashEnem = other.GetComponent<DashEnem>();
            if (dashEnem != null)
            {
                dashEnem.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
