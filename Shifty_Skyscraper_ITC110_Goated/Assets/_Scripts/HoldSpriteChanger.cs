using UnityEngine;

public class HoldSpriteChanger : MonoBehaviour
{
    public bool isPressing = false;
    
    public Sprite baseSprite, newSprite; // Assign the new sprite in the inspector

    private SpriteRenderer spriteRenderer; // Sprite Renderer Component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isPressing)
        {
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
        else
        {
            if (baseSprite != null)
            {
                spriteRenderer.sprite = baseSprite;
            }
        }
    }
}
