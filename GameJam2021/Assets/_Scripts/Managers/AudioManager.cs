using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
#pragma warning disable 0649
    // [SerializeField]
    // private AudioClip musicTrack;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioClip[] footSteps;

    private float musicVolume = 0.25f;
    private float effectVolume = 0.25f;
#pragma warning disable 0649
    private List<AudioClip> tempSteps;

    public float MusicVolume { get => musicSource.volume; set { musicSource.volume = value; } }
    public float EffectVolume { get => effectSource.volume; set { effectSource.volume = value; } }

    private void Start()
    {
        MusicVolume = musicVolume;
        EffectVolume = effectVolume;
        tempSteps.AddRange(footSteps);
        // PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.loop = true;
        // musicSource.clip = musicTrack;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void StopEffect()
    {
        effectSource.Stop();
    }

    public void PlayFootstep()
    {
        int randomStep = Random.Range(0, tempSteps.Count);
        PlayEffect(tempSteps[randomStep]);
        tempSteps.Remove(tempSteps[randomStep]);
        if (tempSteps.Count <= 0) tempSteps.AddRange(footSteps);
    }
}
