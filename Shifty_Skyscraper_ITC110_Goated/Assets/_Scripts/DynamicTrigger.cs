using UnityEngine;
public class DynamicTrigger : MonoBehaviour
{
    // true will enable the object, false will disable the object (has to be disabled for true to work, and vice versa)
    public bool statusChange = true; // can be changed in the inspector
    int objectAmount = 0;
    int triggerSize = 0;
    public GameObject[] enableObject;
    public InteractableSpriteChanger[] objectTrigger;

    private int triggered = 0;

    void Start()
    {
        objectAmount = enableObject.Length;
        triggerSize = objectTrigger.Length;
    }
    
    void Update()
    {
        /*
            Looking to check each objectTrigger before enabling ALL objects
            Use triggerSize to determine loop
        */

        for (int i = 0; i < triggerSize; i++)
        {
            if (objectTrigger[i].hasTriggered)
            {
                triggered++;
            }
            else
            {
                triggered = 0;
                break;
            }
        }

        if (triggered == triggerSize)
        {
            for (int i = 0; i < objectAmount; i++)
            {
                enableObject[i].SetActive(statusChange);
            }
        }
    }
}
