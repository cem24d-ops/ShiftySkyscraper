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
    }
}
