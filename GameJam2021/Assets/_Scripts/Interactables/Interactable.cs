using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<Interactable> OnRightClickEvent;
    public event Action<Interactable> OnPointerEnterEvent;
    public event Action<Interactable> OnPointerExitEvent;
    public InteractableType interactableType;

    [TextArea(15, 20)]
    public string textDialogue;

#pragma warning disable 0649
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Sprite regularSprite;
    [SerializeField]private Sprite highlightedSprite;
    [SerializeField]private Sprite tooltipIndicator;
#pragma warning disable 0649

    public bool isHighlighted = false;
    private bool playerInSight = false;

    private void Start() 
    {
        spriteRenderer.sprite = regularSprite;
    }

    public void Interact()
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
        Highlight();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
