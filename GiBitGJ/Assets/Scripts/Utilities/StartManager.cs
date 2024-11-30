using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public Canvas instruction;

    void Start()
    {
        CloseCanvas();
        AudioManger.Instance.PlayBackgroundMusic(0);
    }

    public void CloseCanvas()
    {
        instruction.gameObject.SetActive(false);
    }

    public void ShowCanvas()
    {
        instruction.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        TransitionManager.Instance.Transition("StartScene", "DialogScene");
    }
}
