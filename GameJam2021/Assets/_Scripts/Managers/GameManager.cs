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
    };

    public void ResetGame()
    {
        foreach (var item in checkpoints)
        {
            checkpoints[item.Key] = false;
        }
        inWorld = true;
    }

    public bool inWorld = true;

    public void OpenMenu()
    {
        inWorld = false;
        GameObject.Instantiate(Resources.Load("Prefabs/Menu/Main"));       
    }
}