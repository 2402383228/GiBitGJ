using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public TMP_Text endText;
    public string Mod;
    public float WaitForSeconds;
    EndScript endScript;
    void Awake()
    {
        endScript = GetComponent<EndScript>();
    }

    void Start()
    {
        endScript.Mod = "None";
        endText.gameObject.SetActive(false);
        if (Mod == "BE")
        {
            PlayBEMusic();
            Invoke(nameof(BEEND), WaitForSeconds);
        }
        else if (Mod == "HE")
        {
            PlayHEMusic();
            Invoke(nameof(HEEND), WaitForSeconds);
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

    void BEEND()
    {
        endText.gameObject.SetActive(true);
        endScript.Mod = "BE";
    }

    void HEEND()
    {
        endText.gameObject.SetActive(true);
        endScript.Mod = "HE";
    }
}
