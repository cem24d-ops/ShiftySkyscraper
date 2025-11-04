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
        if (randomLevel == 2)
            Debug.Log("Level 1");
        if (randomLevel == 3)
        {
            Debug.Log("Level 2A");
        }

        SceneManager.LoadScene(randomLevel);
    }
    
}
