using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableType;
public class GameManager : Singleton<GameManager>
{
    public Dictionary<InteractableType, bool> checkpoints = new Dictionary<InteractableType, bool>
    {
        {R1KEY1, false},
        {R1LETTER, false},
        {R1DRAWER, false},
        {R1CHEST, false},
        {R1PAINTING, false},
        {R1TOME, false},
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