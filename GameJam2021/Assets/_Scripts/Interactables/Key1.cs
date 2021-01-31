using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : Interactable
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.checkpoints[interactableType] = true;
        DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        if(selectionSound != null)
            AudioManager.Instance.PlayEffect(selectionSound);
    }

    public override void Finished()
    {
        base.Finished();
        Destroy(gameObject);
    }
}
