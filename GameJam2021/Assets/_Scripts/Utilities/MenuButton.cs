using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    [SerializeField]private Button button;
    [SerializeField]private Sprite idleSprite;
    [SerializeField]private Sprite hoverSprite;
    [SerializeField]private Sprite selectedSprite;

    private void OnMouseEnter() 
    {
        button.image.sprite = hoverSprite;
    }

    private void OnMouseExit() 
    {
        button.image.sprite = idleSprite;
    }

    private void OnMouseUp() 
    {
        button.image.sprite = hoverSprite;
    }

    private void OnMouseDown() 
    {
        button.image.sprite = selectedSprite;
    }
}
