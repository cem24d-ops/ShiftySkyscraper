using UnityEngine;

public class ElevatorAnimator : MonoBehaviour
{
    public DynamicTrigger Trigger;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if (Trigger.triggerSize == Trigger.triggered)
        {
            animator.SetBool("openElevator", true);
            for (int i = 0; i < 600; i++)
            {
                int help = i;
            }
            //animator.SetBool("openElevator", false);
        }
    }
}
