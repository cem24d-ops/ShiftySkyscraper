using UnityEngine;
public class DynamicTrigger : MonoBehaviour
{
    bool enable = true;
    bool disable = false;
    int enableSize = 0;
    int disableSize = 0;
    public int triggerSize = 0;
    public GameObject[] enableObject;
    public GameObject[] disableObject;
    public InteractableSpriteChanger[] objectTrigger;

    public int triggered = 0;
    void Start()
    {
        enableSize = enableObject.Length;
        disableSize = disableObject.Length;
        triggerSize = objectTrigger.Length;
    }
    
    void FixedUpdate()
    {
        if (triggered < triggerSize)
        {
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
                for (int i = 0; i < enableSize; i++)
                {
                    enableObject[i].SetActive(enable);
                }
                for (int j = 0; j < disableSize; j++)
                {
                    disableObject[j].SetActive(disable);
                }
            }
        }
    }
}
