using UnityEngine;

public class InteractableColorChange : MonoBehaviour
{
    public InteractableSpriteChanger spriteChanger;

    public Color endColor = Color.white;

    // Update is called once per frame
    void Update()
    {
        if (spriteChanger.hasTriggered && spriteChanger != null)
        {
            GetComponent<SpriteRenderer>().color = endColor;
        }
    }
}
