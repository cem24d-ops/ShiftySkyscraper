using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableSpriteChanger : MonoBehaviour, IInteractable
{
    public bool hasTriggered = false;
    
    public Sprite newSprite; // Assign the new sprite in the inspector

    private SpriteRenderer spriteRenderer; // Sprite Renderer Component
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool CanInteract()
    {
        return !hasTriggered;
    }

    // Update is called once per frame
    public void Interact()
    {
        hasTriggered = true;
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
