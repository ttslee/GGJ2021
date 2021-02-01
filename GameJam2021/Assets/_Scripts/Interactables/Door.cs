using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        base.Interact();
        if(GameManager.Instance.checkpoints[InteractableType.KEY2])
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        else
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
    }

    public override void Finished()
    {   
        if(GameManager.Instance.checkpoints[InteractableType.KEY2])
            EndGame();
        base.Finished();
    }

    private void EndGame()
    {
        SceneLoader.Instance.Load(3);
    }
}
