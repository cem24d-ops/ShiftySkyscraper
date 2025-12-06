using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public bool isOpened { get; private set; }

    // Add LevelLoader object in the inspector
    public LevelLoader loader;

    public bool CanInteract()
    {
        //can only interact if the door is closed
        return !isOpened;
    }

    public void Interact()
    {
        // scene changes moved to LevelLoader script
        loader.opened = true;
    }
    
}
