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

    // Tutorial Functions
    private Tutorial curTutorial = null;
    private bool tutorialWait = false;

    private string[] myParsedSentence = new string[] { };

    public void EnableDialogue2(Tutorial tutorial, string text)
    {
        curTutorial = tutorial;

        myText = text.Split('\n');
        textIndex = 0;
        DisplaySentences2();
        displayDialogue.SetActive(true);

        inDialogue = true;
        StartCoroutine(DetectMouseClick2());

        AudioManager.Instance.PlayEffect(dialogueSound[0]);
    }

    private IEnumerator DetectMouseClick2()
    {
        while (inDialogue)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0) && tutorialWait != true)
            {
                AudioManager.Instance.PlayEffect(dialogueSound[0]);
                if (textInProgress != null) waitText = false;
                else
                {
                    DisplaySentences2();
                }
            }
        }
    }

    // Displays text with typwriter effect
    IEnumerator TypeSentence2()
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

    // Handles displaying the next sentences
    public void DisplaySentences2()
    {
        if (myParsedSentence.Length > 0 && CheckText(myParsedSentence[0]))
        {

        }
        else
        {
            displayText.maxVisibleCharacters = 0;
            if (textIndex >= 0 && textIndex < myText.Length)
            {
                myParsedSentence = myText[textIndex++].Split(new[] { ':' }, System.StringSplitOptions.RemoveEmptyEntries);

                if (displayText.maxVisibleCharacters == 0)
                {
                    displayText.text = myParsedSentence[myParsedSentence.Length - 1];
                    textInProgress = StartCoroutine(TypeSentence2());
                }
                else
                {
                    DisplaySentences2();
                }
            }
            else
            {
                EndDialogue2();
            }
        }
    }

    private bool CheckText(string name)
    {
        switch (name)
        {
            case "1":
                tutorialWait = true;
                displayDialogue.SetActive(false);
                curTutorial.First();
                return true;
            case "2":
                tutorialWait = true;
                displayDialogue.SetActive(false);
                curTutorial.Second();
                return true;
            case "3":
                tutorialWait = true;
                displayDialogue.SetActive(false);
                curTutorial.Third();
                return true;
            default:
                return false;
        }
    }

    public void EndDialogue2()
    {
        myParsedSentence = new string[] { };
        StopAllCoroutines();
        displayDialogue.SetActive(false);
        inDialogue = false;
        tutorialWait = false;
        curTutorial.End();
    }

    public void ResumeDialogue()
    {
        myParsedSentence = new string[] { };
        tutorialWait = false;
        displayDialogue.SetActive(true);
        DisplaySentences2();
    }
}
