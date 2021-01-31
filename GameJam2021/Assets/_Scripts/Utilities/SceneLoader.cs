using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField]
    private Animator sceneTransition;
    [SerializeField]
    private Image imageBackground;

    private WaitUntil StartFadeFinished;
    private WaitUntil EndFadeFinished;
    // private int previousScene;
    // private int nextScene;

    protected override void Awake()
    {
        base.Awake();

        StartFadeFinished = new WaitUntil(() => imageBackground.color.a == 1f);
        EndFadeFinished = new WaitUntil(() => imageBackground.color.a == 0f);
    }

    public void Load(int scene)
    {
        // previousScene = SceneManager.GetActiveScene().buildIndex;
        // nextScene = scene;
        StartCoroutine(LoadAsync(scene));
    }

    private IEnumerator LoadAsync(int index)
    {
        sceneTransition.SetTrigger("Start");
        yield return StartFadeFinished;

        AsyncOperation sceneLoading = new AsyncOperation();
        sceneLoading = SceneManager.LoadSceneAsync(index);

        while (!sceneLoading.isDone)
        {
            if (sceneLoading.progress >= 0.9f)
            {
                sceneLoading.allowSceneActivation = true;
            }
            yield return null;
        }

        sceneTransition.SetTrigger("End");
        yield return EndFadeFinished;
    }

    public void Transition(Interactable obj) {
        StartCoroutine(TransitionAsync(obj));
    }

    private IEnumerator TransitionAsync(Interactable obj)
    {
        sceneTransition.SetTrigger("Start");
        yield return StartFadeFinished;
        obj.OpenInteractable();
        sceneTransition.SetTrigger("End");
        yield return EndFadeFinished;
    }
}