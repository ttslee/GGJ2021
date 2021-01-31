using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : Interactable
{
    
    public override void Interact()
    {
        GameManager.Instance.inWorld = false;
        bool myCheckpoint = GameManager.Instance.checkpoints[InteractableType.R1PAINTING];
        if(!myCheckpoint)
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        if(selectionSound != null)
            AudioManager.Instance.PlayEffect(selectionSound);
    }
}
