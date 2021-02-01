using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : Interactable
{
    [SerializeField] private GameObject paintingRef;
    public override void Interact()
    {
        base.Interact();
        DialogueManager.Instance.EnableDialogue(this, readyTextDialogue);
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

    protected override void OnMouseDown()
    {
        // Debug.Log("Interact");
        if (GameManager.Instance.inWorld)
        {
            Interact();
        }
    }
}