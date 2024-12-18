using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        CloseCanvas();
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void PlayButtonSound()
    {
        AudioManger.Instance.PlayButtonSound();
    }
}
