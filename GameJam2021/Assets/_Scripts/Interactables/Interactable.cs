using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Enums.InteractableType interactableType;

    [TextArea(15, 20)]
    public string dialogue;

    public void Interact()
    {
        
    }
}
