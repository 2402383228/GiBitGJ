using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas canvas;
    public DialogManager dialogManager;

    public Button mentionBraceletButton;

    public bool canMentionBracelet;
    public bool isMentionBracelet;

    void Start()
    {
        CloseCanvas();
        isMentionBracelet = false;
        canMentionBracelet = false;
    }

    public void ShowCanvas()
    {
        if (dialogManager.dialogIndex > 15)
        {
            canMentionBracelet = false;
        }
        canvas.gameObject.SetActive(true);
        if (!canMentionBracelet) mentionBraceletButton.gameObject.SetActive(false);
        else mentionBraceletButton.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void OnMentionBracelet()
    {
        isMentionBracelet = true;
        canMentionBracelet = false;
        CloseCanvas();
    }
}
