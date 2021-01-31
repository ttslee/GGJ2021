using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : Interactable
{
    [SerializeField]private GameObject paintingRef;
    public override void Interact()
    {
        base.Interact();
        previousCheckpoint = GameManager.Instance.checkpoints[InteractableType.KEY];
    }

    public override void Finished()
    {
        SceneLoader.Instance.Transition(this);
    }

    public override void OpenInteractable()
    {
        paintingRef.SetActive(true);
        GameManager.Instance.currentInteractable = paintingRef;
    }
}