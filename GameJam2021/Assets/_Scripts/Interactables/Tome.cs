using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : Interactable
{
    
    public override void Interact()
    {
        base.Interact();
        DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        GameManager.Instance.checkpoints[interactableType] = true;
        
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
