using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas canvas;
    public DialogManager dialogManager;

    public Button mentionBraceletButton;
    public Button returnButtonInDialogUI;

    public int canMentionBracelet;
    public int isMentionBracelet;

    void Start()
    {
        CloseCanvas();
    }

    void OnEnable()
    {
        LoadItem();
    }

    void OnDisable()
    {
        SaveItem();
    }

    public void ShowCanvas()
    {
        if (dialogManager.dialogIndex > 15)
        {
            canMentionBracelet = 0;
        }
        canvas.gameObject.SetActive(true);
        if (canMentionBracelet == 0) mentionBraceletButton.gameObject.SetActive(false);
        else mentionBraceletButton.gameObject.SetActive(true);

        returnButtonInDialogUI.gameObject.SetActive(false);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);

        returnButtonInDialogUI.gameObject.SetActive(true);
    }

    public void OnMentionBracelet()
    {
        isMentionBracelet = 1;
        canMentionBracelet = 0;
        CloseCanvas();
    }

    private void SaveItem()
    {
        PlayerPrefs.SetInt("canMentionBracelet", canMentionBracelet);
        PlayerPrefs.SetInt("isMentionBracelet", isMentionBracelet);
    }

    private void LoadItem()
    {
        canMentionBracelet = PlayerPrefs.GetInt("canMentionBracelet", 0);
        isMentionBracelet = PlayerPrefs.GetInt("isMentionBracelet", 0);
        Debug.Log(isMentionBracelet);
    }
}
