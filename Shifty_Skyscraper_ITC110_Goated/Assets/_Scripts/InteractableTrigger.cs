using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    // true will enable the object, false will disable the object (has to be disabled for true to work, and vice versa)
    public bool statusChange = true; // can be changed in the inspector
    public GameObject enableObject1, enableObject2;
    public InteractableSpriteChanger Object1, Object2, Object3, Object4;
    
    void Update()
    {
        // haven't figured a way to do any combination without a lot of if statements, so repeat objects in the inspector so it will work properly
        if ( Object1.hasTriggered && Object2.hasTriggered && Object3.hasTriggered && Object4.hasTriggered )
        {
            if (enableObject1 != null)
                enableObject1.SetActive(statusChange);
            if (enableObject2 != null)
                enableObject2.SetActive(statusChange);
        }
    }
}
