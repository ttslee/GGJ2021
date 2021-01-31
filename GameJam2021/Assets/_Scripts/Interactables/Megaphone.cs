using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : Interactable
{
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.RECORD];
        if(!previousCheckpoint)
        {
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
            StartCoroutine(AudioManager.Instance.DampenForAudioClip(.1f));
            GameManager.Instance.checkpoints[InteractableType.MEGAPHONE] = true;
        }
        else
            base.Finished();
    }
}
