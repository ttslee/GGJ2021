using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableType;
public class GameManager : Singleton<GameManager>
{
    public Dictionary<InteractableType, bool> checkpoints = new Dictionary<InteractableType, bool>
    {
        {KEY, false},
        {KEY2, false},
        {CABINET, false},
        {RECORD, false},
        {MEGAPHONE, false},
        {CLOCK, false},
        {FIREPLACE, false},
        {PAINTING, false},
        {TOME, false},
        {DOOR, false},
    };

    public void ResetGame()
    {
        List<InteractableType> tempKeys = new List<InteractableType>();
        foreach (InteractableType item in checkpoints.Keys) tempKeys.Add(item);
        foreach (InteractableType item in tempKeys) checkpoints[item] = false;
        inWorld = true;
    }

    public bool menuOpen = false;
    public bool inWorld = true;
    public GameObject currentInteractable;
    
    public void OpenMenu()
    {
        menuOpen = true;
        inWorld = false;
        (GameObject.Instantiate(Resources.Load("Prefabs/Menu/Main")) as GameObject).GetComponent<Menu>().PlaySound();
    }
}