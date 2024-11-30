using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlayButtonSound()
    {
        AudioManger.Instance.PlayButtonSound();
    }
}
