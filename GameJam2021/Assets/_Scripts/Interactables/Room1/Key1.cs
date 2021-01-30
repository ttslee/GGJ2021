using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : Interactable
{
    public override void Interact()
    {
        GameManager.Instance.checkpoints[interactableType] = true;
        AudioManager.Instance.PlayEffect(selectionSound);
    }
}
