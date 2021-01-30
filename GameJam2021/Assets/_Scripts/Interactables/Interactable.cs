using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class Interactable : MonoBehaviour
{
    // public event Action<Interactable> OnRightClickEvent;
    // public event Action<Interactable> OnPointerEnterEvent;
    // public event Action<Interactable> OnPointerExitEvent;
    public InteractableType interactableType;

    [TextArea(5, 5)]
    public string readyTextDialogue;
    [TextArea(5, 5)]
    public string incompleteTextDialogue;


#pragma warning disable 0649
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Sprite regularSprite;
    [SerializeField]private Sprite highlightedSprite;
    [SerializeField]private Sprite tooltipIndicator;
    [SerializeField]private AudioClip proximitySound;
    [SerializeField]private AudioClip selectionSound;
#pragma warning disable 0649

    public bool isHighlighted = false;
    private bool playerInSight = false;

    private void Start() 
    {
        spriteRenderer.sprite = regularSprite;
    }

    public virtual void Interact()
    {
        GameManager.Instance.checkpoints[interactableType] = true;
    }

    private void ShowTooltip()
    {

    }

    private void HideTooltip()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(proximitySound != null)
            AudioManager.Instance.PlayEffect(proximitySound);
        Highlight();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(proximitySound != null)
            AudioManager.Instance.StopEffect();
        RemoveHighlight(); 
    }

    private void Highlight()
    {
        isHighlighted = true;
        spriteRenderer.sprite = highlightedSprite;
        Debug.Log("Highlighted");
    }

    private void RemoveHighlight()
    {
        isHighlighted = false;
        spriteRenderer.sprite = regularSprite;
        Debug.Log("NOT HIGHLITHTEDGA");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && isHighlighted)
        {
            Interact();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch(GameManager.Instance.inWorld)
        {
            case true:
                if(playerInSight)
                    ShowTooltip();
                break;
            default:
                Highlight();
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!GameManager.Instance.inWorld)
            RemoveHighlight();
        else
            HideTooltip();
    }
}
