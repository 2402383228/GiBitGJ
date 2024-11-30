using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public string musicMod;
    void Start()
    {
        if (musicMod == "BE")
        {
            PlayBEMusic();
        }
        else if (musicMod == "HE")
        {
            PlayHEMusic();
        }
    }

    void PlayBEMusic()
    {
        AudioManger.Instance.PlayBackgroundMusic(5);
    }

    void PlayHEMusic()
    {
        AudioManger.Instance.PlayBackgroundMusic(4);
    }
}
