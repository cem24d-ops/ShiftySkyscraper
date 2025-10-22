using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; // The interactable object currently in range
    public GameObject interactionIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the interaction icon to be inactive at the start
        interactionIcon.SetActive(false);
    }

    public void OnInteract()
    {
        if (interactableInRange != null)
        {
            interactableInRange.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is interactable
        if (other.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            // Show interaction icon
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger is the interactable we are tracking
        if (other.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            // Hide interaction icon
            interactionIcon.SetActive(false);
        }
    }
}
