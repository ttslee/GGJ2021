using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : Interactable
{
    
    public override void Interact()
    {
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.R1PAINTING];
        if(!previousCheckpoint)
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        if(selectionSound != null)
            AudioManager.Instance.PlayEffect(selectionSound);
    }

    public override void Finished()
    {
        base.Finished();
        if(previousCheckpoint)
            SceneLoader.Instance.Load(0);
    }
}
