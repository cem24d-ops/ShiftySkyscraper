using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public Indicator[] indicators;
    int triggered = 0, triggerSize = 0;

    void Start()
    {
        triggerSize = indicators.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered < triggerSize)
        {
            for (int i = 0; i < triggerSize; i++)
            {
                if (indicators[i].waiting)
                {
                    triggered++;
                }
                else
                {
                    triggered = 0;
                    break;
                }
            }
        }
        if (triggered == triggerSize)
        {
            for (int j = 0; j < triggerSize; j++)
            {
                indicators[j].done = true;
            }
        }
    }
}
