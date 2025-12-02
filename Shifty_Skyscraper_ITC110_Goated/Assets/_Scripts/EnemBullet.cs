using UnityEngine;

public class EnemBullet : MonoBehaviour
{
    public int damage;
    public LayerMask playerLayers;
    Canvas gameCanvas;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by enemy bullet: " + other.name);
            gameCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            if (gameCanvas != null)
            {
                gameCanvas.GetComponent<GameManager>().LoseLife();
            }
        }
        if (other.CompareTag("Ground") || other.CompareTag("Enemy") || other.CompareTag("RangedEnem"))
        {
            Debug.Log("Enemy bullet hit: " + other.name);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

