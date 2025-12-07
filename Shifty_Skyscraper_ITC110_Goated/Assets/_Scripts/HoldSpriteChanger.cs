using UnityEngine;

public class HoldSpriteChanger : MonoBehaviour, IInteractable
{
    public bool isPressing = false;
    
    public Sprite baseSprite, newSprite; // Assign the new sprite in the inspector

    private SpriteRenderer spriteRenderer; // Sprite Renderer Component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool CanInteract()
    {
        return !isPressing;
    }
    
    public void Interact()
    {
        
    }

    public void FixedUpdate()
    {
        if (isPressing)
        {
            if (newSprite != null)
                spriteRenderer.sprite = newSprite;
        }
        else if (!isPressing)
        {
            if (baseSprite != null)
                spriteRenderer.sprite = baseSprite;
        }
    }
}
