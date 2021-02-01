using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class Interactable : MonoBehaviour
{
    public InteractableType interactableType;

    [TextArea(5, 5)]
    public string readyTextDialogue;
    [TextArea(5, 5)]
    public string incompleteTextDialogue;


#pragma warning disable 0649
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite regularSprite;
    [SerializeField] private Sprite highlightedSprite;
#pragma warning disable 0649
    public AudioClip proximitySound;
    public AudioClip selectionSound;
    public bool isHighlighted = false;
    private bool playerInSight = false;
    public bool previousCheckpoint;
    private void Start()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = regularSprite;
    }

    public virtual void Interact()
    {
        GameManager.Instance.inWorld = false;
    }

    public virtual void Finished()
    {
        GameManager.Instance.inWorld = true;
    }

    public virtual void OpenInteractable()
    {

    }

    private void ShowTooltip()
    {

    }

    private void HideTooltip()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            if (other.gameObject.tag == "Player" && proximitySound != null)
            {
                AudioManager.Instance.PlayEffect(proximitySound);
                AudioManager.Instance.MusicVolume = .1f;
            }
            if (other.gameObject.tag == "Detector")
            {
                Highlight();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            if (other.gameObject.tag == "Player" && proximitySound != null)
            {
                AudioManager.Instance.StopEffect();
                AudioManager.Instance.MusicVolume = .25f;
            }
            if (other.gameObject.tag == "Detector")
            {
                RemoveHighlight();
            }
        }
    }

    private void Highlight()
    {
        isHighlighted = true;
        if(highlightedSprite)
            spriteRenderer.sprite = highlightedSprite;
    }

    private void RemoveHighlight()
    {
        isHighlighted = false;
        if(regularSprite)
            spriteRenderer.sprite = regularSprite;
    }

    protected virtual void OnMouseDown()
    {
        // Debug.Log("Interact");
        if (isHighlighted && GameManager.Instance.inWorld)
        {
            Interact();
        }
    }

    private void OnMouseEnter()
    {
        // Debug.Log("Enter");
        switch (GameManager.Instance.inWorld)
        {
            case true:
                if (playerInSight)
                    ShowTooltip();
                break;
            default:
                Highlight();
                break;
        }
    }

    private void OnMouseExit()
    {
        // Debug.Log("Exit");
        if (!GameManager.Instance.inWorld)
            RemoveHighlight();
        else
            HideTooltip();
    }
}
