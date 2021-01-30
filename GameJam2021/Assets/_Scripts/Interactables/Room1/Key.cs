using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public override void Interact()
    {
        GameManager.Instance.checkpoints[InteractableType.KEY1] = true;
    }
}
