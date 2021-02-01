using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : Interactable
{
    [SerializeField]private GameObject tome;
    [SerializeField]private GameObject key2;
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.CLOCK];
        if(previousCheckpoint)
        {
            GameManager.Instance.checkpoints[interactableType] = true;
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
            tome.SetActive(true);
            key2.SetActive(true);
            gameObject.SetActive(false);
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
