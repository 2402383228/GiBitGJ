using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    Teleport teleport;

    private void Awake()
    {
        teleport = GetComponent<Teleport>();
    }
    public void OnDialogClick()
    {
        if (ItemManager.canMentionBracelet == 1 && ItemManager.isMentionBracelet == 0)
        {
            PlayerPrefs.SetInt("dialogIndex", 17);
        }
        teleport.TeleportToScene();
    }
}
