using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //MAIN MENU
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private GameObject controls;
    [SerializeField]
    private GameObject control;

    public void OnPlay()
    {
        GameManager.Instance.inWorld = true;
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

    // OPENING
    public void Skip()
    {
        SceneLoader.Instance.Load(2);
    }

}
