using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    public GameObject enableObject;
    public InteractableSpriteChanger Object1;
    public InteractableSpriteChanger Object2;
    public InteractableSpriteChanger Object3;
    public InteractableSpriteChanger Object4;

    void Update()
    {
        if ( Object1.hasTriggered && Object2.hasTriggered && Object3.hasTriggered && Object4.hasTriggered )
        {
            enableObject.SetActive(true);
        }
    }
}
