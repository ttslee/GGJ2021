using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Interactable
{
    [SerializeField]private GameObject cabinetRef;
    [SerializeField]private AudioClip lockedSound;
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.KEY];
        if(!previousCheckpoint)
        {
            AudioManager.Instance.PlayEffect(lockedSound);
            DialogueManager.Instance.EnableDialogue(this, incompleteTextDialogue);
        }
        else
        {
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        }
    }

    public override void Finished()
    {
        if(previousCheckpoint)
        {
            AudioManager.Instance.PlayEffect(selectionSound);
            SceneLoader.Instance.Transition(this);
        }
        else
            base.Finished();
    }

    public override void OpenInteractable()
    {
        cabinetRef.SetActive(true);
    }
}
