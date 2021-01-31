using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Interactable
{
    [SerializeField]private GameObject clockRef;

    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.MEGAPHONE];
        if(!previousCheckpoint)
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        else
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
    }

    public override void Finished()
    {
        OpenInteractable();
    }

    public void OpenInteractable()
    {
        clockRef.SetActive(true);
    }
}
