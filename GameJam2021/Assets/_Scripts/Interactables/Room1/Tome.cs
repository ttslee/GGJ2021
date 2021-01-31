using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : Interactable
{
    
    public override void Interact()
    {
        bool myCheckpoint = GameManager.Instance.checkpoints[InteractableType.R1PAINTING];
        if(!myCheckpoint)
            return;
        
        AudioManager.Instance.PlayEffect(selectionSound);
    }
}
