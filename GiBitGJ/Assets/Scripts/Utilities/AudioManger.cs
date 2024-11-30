using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManger : Singleton<AudioManger>
{
    public AudioSource backgroundMusicSource;
    public AudioSource sfxSource;
    public AudioClip[] backgroundMusicClip;
    public AudioClip soundEffects;

    public void PlayBackgroundMusic(int index)
    {
        backgroundMusicSource.clip = backgroundMusicClip[index];
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlaySoundEffect()
    {
        sfxSource.PlayOneShot(soundEffects);
    }
}