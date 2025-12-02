using UnityEngine;

public class EnemBullet : MonoBehaviour
{
    public int damage;
    Canvas gameCanvas;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameCanvas.GetComponent<GameManager>().LoseLife();
        }
    }
}

