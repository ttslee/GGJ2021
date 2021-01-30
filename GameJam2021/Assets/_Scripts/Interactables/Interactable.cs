using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableType interactableType;

    [TextArea(15, 20)]
    public string textDialogue;

    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Sprite regularSprite;
    [SerializeField]private Sprite highlightedSprite;
    public void Interact()
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
        spriteRenderer.sprite = highlightedSprite;
    }

    private void RemoveHighlight()
    {
        spriteRenderer.sprite = regularSprite;
    }
}
