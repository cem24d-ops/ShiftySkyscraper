using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    GameManager gameManager;
    // Start is called once before the
    //  first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        StaticData.visited = 0;
        SceneManager.LoadScene(0);
        gameManager.numberOfLives = 5;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
} 