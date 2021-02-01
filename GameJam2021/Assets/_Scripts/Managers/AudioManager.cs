using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
#pragma warning disable 0649
    public AudioClip[] musicTrack;
    public AudioSource musicSource;
    public AudioSource ambientSource;
    public AudioSource effectSource;
    [SerializeField]
    private AudioClip[] footSteps;

    private float musicVolume = 0.2f;
    private float ambientVolume = 0.2f;
    private float effectVolume = 0.2f;
#pragma warning disable 0649
    private List<AudioClip> tempSteps = new List<AudioClip>();

    public float MusicVolume { get => musicSource.volume; set { musicSource.volume = value; } }
    public float AmbientVolume { get => ambientSource.volume; set { ambientSource.volume = value; } }
    public float EffectVolume { get => effectSource.volume; set { effectSource.volume = value; } }

    private void Start()
    {
        MusicVolume = musicVolume;
        AmbientVolume = ambientVolume;
        EffectVolume = effectVolume;
        tempSteps.AddRange(footSteps);
        PlayMusic(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayMusic(int scene)
    {
        musicSource.loop = true;
        musicSource.clip = musicTrack[scene];
        musicSource.Play();
    }

    public void PlayAmbience(AudioClip clip)
    {
        ambientSource.clip = clip;
        ambientSource.Play();
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

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    public void PlayFootstep()
    {
        int randomStep = Random.Range(0, tempSteps.Count);
        PlayEffect(tempSteps[randomStep]);
        tempSteps.Remove(tempSteps[randomStep]);
        if (tempSteps.Count <= 0) tempSteps.AddRange(footSteps);
    }

    public IEnumerator DampenForAudioClip(float volume)
    {
        MusicVolume = volume;
        while (effectSource.isPlaying)
        {
            yield return null;
        }
        MusicVolume = musicVolume;
    }
}
