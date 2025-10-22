using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public bool isOpened { get; private set; }

    public bool CanInteract()
    {
        //can only interact if the door is closed
        return !isOpened;
    }
    public void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
