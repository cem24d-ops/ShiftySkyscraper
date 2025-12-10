using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        gameManager.numberOfLives = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Level Restarted");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        StaticData.visited = 0;
        SceneManager.LoadScene(0);
        gameManager.numberOfLives = 5;
    }
}
