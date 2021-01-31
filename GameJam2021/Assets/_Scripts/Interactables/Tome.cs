using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : Interactable
{
    
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.PAINTING];
        if(!previousCheckpoint)
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        
    }

    public override void Finished()
    {
        if(selectionSound != null)
            AudioManager.Instance.PlayEffect(selectionSound);
        base.Finished();
        if(previousCheckpoint)
            SceneLoader.Instance.Load(0);
        Destroy(gameObject);
    }
}
