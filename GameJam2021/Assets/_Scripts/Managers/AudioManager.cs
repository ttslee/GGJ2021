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
#pragma warning disable 0649

    public float MusicVolume { get => musicSource.volume; set { musicSource.volume = value; } }
    public float EffectVolume { get => effectSource.volume; set { effectSource.volume = value; } }

    // private void Start() => PlayMusic();

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
}
