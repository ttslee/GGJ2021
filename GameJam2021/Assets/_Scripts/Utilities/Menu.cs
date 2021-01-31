using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject controls;
    [SerializeField]
    private GameObject credits;

    public void OnPlay()
    {
        GameManager.Instance.ResetGame();
        SceneLoader.Instance.Load(1);
    }

    public void OnResume()
    {
        GameManager.Instance.inWorld = true;
        Destroy(this.gameObject);
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnControls()
    {
        controls.SetActive(true);
    }

    public void CloseControls()
    {
        controls.SetActive(false);
    }

    public void OnCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    // OPENING
    public void Skip()
    {
        SceneLoader.Instance.Load(2);
    }
}
