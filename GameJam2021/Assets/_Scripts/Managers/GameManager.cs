using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableType;
public class GameManager : Singleton<GameManager>
{
    public Dictionary<InteractableType, bool> checkpoints = new Dictionary<InteractableType, bool>
    {
        {KEY, false},
        {CABINET, false},
        {RECORD, false},
        {MEGAPHONE, false},
        {CLOCK, false},
        {FIREPLACE, false},
        {PAINTING, false},
        {TOME, false},
    };

    public void ResetGame()
    {
        List<InteractableType> tempKeys = new List<InteractableType>();
        foreach(InteractableType item in checkpoints.Keys) tempKeys.Add(item);
        foreach (InteractableType item in tempKeys) checkpoints[item] = false;
        inWorld = true;
    }

    public bool inWorld = true;

    public void OpenMenu()
    {
        inWorld = false;
        GameObject.Instantiate(Resources.Load("Prefabs/Menu/Main"));       
    }
}