using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public int numberOfPickups = 0;
    public int numberOfLives = 5;

    //public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public Vector3 spawnPoint1;
    public Vector3 spawnPoint2;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint1 = new Vector3(-8, -3.73f, 0);
        spawnPoint2 = new Vector3(-7, -3.73f, 0);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Keys: " + numberOfPickups;
        livesText.text = "Lives Remaining: " + numberOfLives;
    }
}
