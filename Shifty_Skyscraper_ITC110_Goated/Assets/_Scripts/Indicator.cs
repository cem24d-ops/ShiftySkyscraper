using UnityEngine;

public class Indicator : MonoBehaviour
{
    Animator animator;
    public InteractableSpriteChanger spriteChanger;
    public bool waiting = false, done = false;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (spriteChanger.hasTriggered)
        {
            animator.SetTrigger("Triggered");
            waiting = true;
        }
        
        if (done)
        {
            animator.SetTrigger("allTriggered");
        }
    }
}
