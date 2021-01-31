using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : Interactable
{
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.CLOCK];
        if(previousCheckpoint)
        {
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        }
        else
        {
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        }
    }

    public override void Finished()
    {
        base.Finished();
    }
}
