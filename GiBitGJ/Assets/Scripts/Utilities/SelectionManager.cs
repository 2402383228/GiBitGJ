using System.Collections;
using System.Collections.Generic;
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
}
