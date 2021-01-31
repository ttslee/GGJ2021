using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]private GameObject control;
    [SerializeField]private GameObject credits;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            control.SetActive(true);
    }

    public void Resume()
    {
        control.SetActive(false);
    }

    public void OnQuit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
