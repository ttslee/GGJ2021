using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField]private AudioClip clickedSound;

    public void Clicked()
    {
        AudioManager.Instance.PlayEffect(clickedSound);
        GameManager.Instance.checkpoints[InteractableType.RECORD] = true;
        Destroy(gameObject);
    }
}
