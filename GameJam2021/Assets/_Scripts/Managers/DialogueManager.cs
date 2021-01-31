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

    private Interactable selectedObject;
    private string[] myText;
    private int textIndex;
    private bool waitText = true;
    private Coroutine textInProgress = null;
    private WaitForSeconds textDelay = new WaitForSeconds(0.01f);

    public void EnableDialogue(Interactable obj, string text)
    {
        selectedObject = obj;

        myText = text.Split('\n');
        textIndex = 0;
        DisplaySentences();
        displayDialogue.SetActive(true);
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
        displayDialogue.SetActive(false);
        selectedObject.Interact();
    }
}
