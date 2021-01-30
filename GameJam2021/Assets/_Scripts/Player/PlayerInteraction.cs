using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInteraction : MonoBehaviour
{
    public event Action<Interactable> OnRightClickEvent;
    public event Action<Interactable> OnPointerEnterEvent;
    
    private void Awake() 
    {
        
    }
}
