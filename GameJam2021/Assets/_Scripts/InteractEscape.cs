using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEscape : MonoBehaviour
{
    public AudioClip clickSound;

    public void Close()
    {
        AudioManager.Instance.PlayEffect(clickSound);
        GameManager.Instance.CloseInteractable();
    }
}
