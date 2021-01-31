using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField]
    private GameObject displayDialogue;
    [SerializeField]
    private TextMeshProUGUI displayText;

    private bool inDialogue = false;
    private Interactable selectedObject;
    private string[] myText;
    private int textIndex;
    private bool waitText = true;
    private Coroutine textInProgress = null;
    private WaitForSeconds textDelay = new WaitForSeconds(0.01f);

    [SerializeField]
    private AudioClip[] dialogueSound;

    private IEnumerator DetectMouseClick()
    {
        while (inDialogue)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.Instance.PlayEffect(dialogueSound[0]);
                if (textInProgress != null) waitText = false;
                else
                {
                    DisplaySentences();
                }
            }
        }
    }

    public void EnableDialogue(Interactable obj, string text)
    {
        if (!inDialogue)
        {
            selectedObject = obj;

            myText = text.Split('\n');
            textIndex = 0;
            DisplaySentences();
            displayDialogue.SetActive(true);

            inDialogue = true;
            StartCoroutine(DetectMouseClick());

            AudioManager.Instance.PlayEffect(dialogueSound[0]);
        }
    }

    // Handles displaying the next sentences
    public void DisplaySentences()
    {
        displayText.maxVisibleCharacters = 0;
        if (textIndex >= 0 && textIndex < myText.Length)
        {
            if (displayText.maxVisibleCharacters == 0)
            {
                displayText.text = myText[textIndex++];
                textInProgress = StartCoroutine(TypeSentence());
            }
            else
            {
                DisplaySentences();
            }
        }
        else
        {
            EndDialogue();
        }
    }

    // Displays text with typwriter effect
    IEnumerator TypeSentence()
    {
        int textCount = displayText.text.Length;
        while (displayText.maxVisibleCharacters < textCount)
        {
            if (waitText == true)
            {
                displayText.maxVisibleCharacters++;
                yield return textDelay;
            }
            else displayText.maxVisibleCharacters = textCount;
        }
        textInProgress = null;
        waitText = true;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        displayDialogue.SetActive(false);
        selectedObject.Finished();
        inDialogue = false;
    }
}
