using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject controls;
    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private AudioClip buttonSound;

    public void PlaySound()
    {
        AudioManager.Instance.PlayEffect(buttonSound);
    }

    public void OnPlay()
    {
        PlaySound();

        GameManager.Instance.ResetGame();
        SceneLoader.Instance.Load(1);
    }

    public void OnResume()
    {
        GameManager.Instance.menuOpen = false;
        PlaySound();
        GameManager.Instance.inWorld = true;
        Destroy(this.gameObject);
    }

    public void OnQuit()
    {
        PlaySound();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnMenu()
    {
        PlaySound();

        SceneLoader.Instance.Load(0);
    }

    public void OnControls()
    {
        PlaySound();

        if (controls != null)
            controls.SetActive(true);
    }

    public void CloseControls()
    {
        PlaySound();

        controls.SetActive(false);
    }

    public void OnCredits()
    {
        PlaySound();

        if (credits != null)
            credits.SetActive(true);
    }

    public void CloseCredits()
    {
        PlaySound();

        credits.SetActive(false);
    }

    // OPENING
    public void Skip()
    {
        PlaySound();

        SceneLoader.Instance.Load(2);
    }
}
