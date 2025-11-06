using UnityEngine;

public class HoldTrigger : MonoBehaviour
{
    // true will enable the object, false will disable the object (has to be disabled for true to work, and vice versa)
    public bool statusChange = true; // can be changed in the inspector
    public int objectAmount = 0;
    public GameObject[] enableObject;
    public InteractableSpriteChanger objectTrigger1, objectTrigger2;
    public PlayerMovement player1, player2;

    void Start()
    {
        objectAmount = enableObject.Length;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(player1.interactKey) && Input.GetKey(player2.interactKey))
            {
                for (int i = 0; i < objectAmount; i++)
                {
                    enableObject[i].SetActive(statusChange);
                }
                Debug.Log("interact p1 + p2");
            }
        }
    }
}
