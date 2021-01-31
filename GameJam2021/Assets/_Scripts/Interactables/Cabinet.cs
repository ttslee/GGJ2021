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
            AudioManager.Instance.PlayEffect(selectionSound);
            DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
        }
    }

    public override void Finished()
    {
        if(previousCheckpoint)
            OpenCabinet();
        else
            base.Finished();
    }

    private void OpenCabinet()
    {
        cabinetRef.SetActive(true);
    }
}
