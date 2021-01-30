using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<InteractableType,bool> checkpoints;
   
    public bool inWorld = true;
}
