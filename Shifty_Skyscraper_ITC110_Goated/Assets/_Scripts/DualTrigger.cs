using UnityEngine;
public class DualTrigger : MonoBehaviour
{
    public string Title;
    bool enable = true;
    bool disable = false;
    int enableSize = 0;
    int disableSize = 0;

    public GameObject[] enableObject, disableObject;
    public HoldSpriteChanger objectTrigger1, objectTrigger2;
    public PlayerMovement player1, player2;
    public Collider2D button1, button2, p1Col, p2Col;

    bool triggered = false;

    void Start()
    {
        enableSize = enableObject.Length;
        disableSize = disableObject.Length;

        button1 = button1.GetComponent<Collider2D>();
        button2 = button2.GetComponent<Collider2D>();
        p1Col = p1Col.GetComponent<Collider2D>();
        p2Col = p2Col.GetComponent<Collider2D>();

    }
    void FixedUpdate()
    {
        if ((p1Col.IsTouching(button1) && p2Col.IsTouching(button2)) || (p1Col.IsTouching(button2) && p2Col.IsTouching(button1)))
        {
            if (Input.GetKey(player1.interactKey) && Input.GetKey(player2.interactKey))
            {
                objectTrigger1.isPressing = true;
                objectTrigger2.isPressing = true;
                for (int i = 0; i < enableSize; i++)
                {
                    enableObject[i].SetActive(enable);
                }

                for (int j = 0; j < disableSize; j++)
                {
                    disableObject[j].SetActive(disable);
                }
                triggered = true;
            }
        }
        
        if (!triggered)
        {
            if ((p1Col.IsTouching(button1) && Input.GetKey(player1.interactKey)) || (p2Col.IsTouching(button1) && Input.GetKey(player2.interactKey)))
            {
                objectTrigger1.isPressing = true;
            }
            else
            {
                objectTrigger1.isPressing = false;
            }

            if ((p1Col.IsTouching(button2) && Input.GetKey(player1.interactKey)) || (p2Col.IsTouching(button2) && Input.GetKey(player2.interactKey)))
            {
                objectTrigger2.isPressing = true;
            }
            else
            {
                objectTrigger2.isPressing = false;
            }
        }

        
    }
}
