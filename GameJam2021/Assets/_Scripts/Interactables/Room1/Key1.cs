using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : Interactable
{
    public override void Interact()
    {
        GameManager.Instance.inWorld = false;
        GameManager.Instance.checkpoints[interactableType] = true;
        if(selectionSound != null)
            AudioManager.Instance.PlayEffect(selectionSound);
        DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        Destroy(gameObject);
    }
}
