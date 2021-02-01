using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Tutorial : MonoBehaviour
{
    [TextArea(5, 5)]
    public string textDialogue;

    public GameObject playerLight = null;
    private WaitForSeconds stepDelay = new WaitForSeconds(0.4f);

    public AudioClip lanternLight;
    public Light2D globalLight;

    protected virtual void Start()
    {
        DialogueManager.Instance.EnableDialogue2(this, textDialogue);
    }

    public virtual void First()
    {
        StartCoroutine(FootSteps());
    }

    protected virtual IEnumerator FootSteps()
    {
        int count = 0;
        while (count != 3)
        {
            AudioManager.Instance.PlayFootstep();
            yield return stepDelay;
            count++;
        }
        yield return new WaitForSeconds(2.5f);
        Resume();
    }

    public virtual void Second()
    {
        StartCoroutine(SecondAsync());
    }

    protected virtual IEnumerator SecondAsync()
    {
        yield return new WaitForSeconds(1.5f);
        globalLight.intensity = Mathf.Lerp(globalLight.intensity, 0.1f, 1f);
        AudioManager.Instance.PlayEffect(lanternLight);
        playerLight.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Resume();
    }

    public virtual void Third()
    {
        StartCoroutine(ThirdAsync());
    }

    protected virtual IEnumerator ThirdAsync()
    {
        yield return new WaitForSeconds(1.5f);
        Resume();
    }

    public virtual void Finish()
    {
        SceneLoader.Instance.Load(2);
    }

    protected virtual void Resume()
    {
        DialogueManager.Instance.ResumeDialogue();
    }
}
