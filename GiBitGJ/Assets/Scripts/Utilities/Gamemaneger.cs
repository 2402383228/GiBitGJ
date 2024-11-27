using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    void OnDestroy()
    {
        PlayerPrefs.SetInt("dialogIndex", 1);
        PlayerPrefs.SetInt("canMentionBracelet", 0);
        PlayerPrefs.SetInt("isMentionBracelet", 0);
        PlayerPrefs.Save();
    }
}
