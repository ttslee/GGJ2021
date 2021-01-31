using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private GameObject credits;

    public void OnPlay()
    {
        SceneLoader.Instance.Load(1);
    }

    public void OnCredits()
    {
        credits.gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.gameObject.SetActive(false);
    }

    public void OnQuit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
