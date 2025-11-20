using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public bool isOpened { get; private set; }
    public int minInclusive = 0, maxExclusive = 0;

    public bool CanInteract()
    {
        //can only interact if the door is closed
        return !isOpened;
    }

    public void Interact()
    {
        int randomLevel = Random.Range(minInclusive, maxExclusive);
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (randomLevel != currentScene)
        {
            SceneManager.LoadScene(randomLevel);
        }

        while (randomLevel == currentScene)
        {
            randomLevel = Random.Range(minInclusive, maxExclusive);

            if (randomLevel != currentScene)
                SceneManager.LoadScene(randomLevel);
        }
        
    }
    
}
