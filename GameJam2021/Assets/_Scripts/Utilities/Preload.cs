using UnityEngine;

public class Preload : MonoBehaviour
{
    private static string[] prefabs = {
            "Prefabs/SceneLoader",
            "Prefabs/Managers/AudioManager",
            "Prefabs/Managers/GameManager",
            "Prefabs/Managers/DialogueManager"
        };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void preload()
    {
        Debug.Log("Preloading " + prefabs.Length + " Objects");
        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject.Instantiate(Resources.Load(prefabs[i]));
            //Debug.Log("Preloading: " + prefabs[i]);
        }
    }
}