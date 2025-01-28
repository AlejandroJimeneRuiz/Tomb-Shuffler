using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interaction_objects : MonoBehaviour
{
    public string InteractionText = "Press E to Interact";
  public UnityEvent onInteract;

    public string GetInteractionText()
    {
        return InteractionText;
    }
    public void Interact()
    {
        onInteract.Invoke();
    }
}
