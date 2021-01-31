using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClockPuzzle : MonoBehaviour
{
    [SerializeField]private AudioClip completionSound;
    [SerializeField]private AudioClip clickingSound;
    private int[] code = {1, 2, 2, 5};

    public int currentIndex;

    public void PlaySound()
    {
        AudioManager.Instance.PlayEffect(clickingSound);
    }

    public void CheckCorrect(int val)
    {
        PlaySound();
        if(code[currentIndex] == val)
            currentIndex++;
        else
            currentIndex = 0;
        if(currentIndex == 4)
        {
            AudioManager.Instance.PlayEffect(completionSound);
        }
            
    }
}
