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

    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Sprite regularSprite;
    [SerializeField]private Sprite highlightedSprite;
    [SerializeField]private Sprite tooltipIndicator;
    
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

    private void OnCollisionExit(Collision other) 
    {
        RemoveHighlight();    
    }

    private void OnCollisionEnter(Collision other) 
    {
        Highlight();
    }

    private void Highlight()
    {
        isHighlighted = true;
        spriteRenderer.sprite = highlightedSprite;
    }

    private void RemoveHighlight()
    {
        isHighlighted = false;
        spriteRenderer.sprite = regularSprite;
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
