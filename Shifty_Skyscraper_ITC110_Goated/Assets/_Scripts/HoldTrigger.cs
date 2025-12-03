using UnityEngine;

public class HoldTrigger : MonoBehaviour
{
    public string Title;
    // true will enable the object, false will disable the object (has to be disabled for true to work, and vice versa)
    bool enable = true, disable = false;    
    int enableSize = 0;
    int disableSize = 0;

    public GameObject[] enableObject, disableObject;
    public HoldSpriteChanger objectTrigger;
    public PlayerMovement player1, player2;
    public Collider2D button, p1Col, p2Col;
    bool triggered = false;

    void Start()
    {
        enableSize = enableObject.Length;
        disableSize = disableObject.Length;
    }
    void FixedUpdate()
    {
        if ((p1Col.IsTouching(button) && Input.GetKey(player1.interactKey)) || (p2Col.IsTouching(button) && Input.GetKey(player2.interactKey)))
        {
            objectTrigger.isPressing = true;
            WhenHolding();
            
            enable = true; disable = false;
        }
        else
        {
            enable = false; disable = true;
            WhenHolding();
        }

        if (!triggered)
        {
            if ((p1Col.IsTouching(button) && Input.GetKey(player1.interactKey)) || (p2Col.IsTouching(button) && Input.GetKey(player2.interactKey)))
            {
                objectTrigger.isPressing = true;
            }
            else
            {
                objectTrigger.isPressing = false;
            }
        }
    }

    void WhenHolding()
    {
        for (int i = 0; i < enableSize; i++)
        {
            enableObject[i].SetActive(enable);
        }
        for (int i = 0; i < disableSize; i++)
        {
            disableObject[i].SetActive(disable);
        }
    }
}
