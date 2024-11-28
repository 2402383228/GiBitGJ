using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipManger : MonoBehaviour
{
    public Canvas SkipCanvas;
    public Button enterDreamButtonInBarUI;
    public Button dialogButtonInBarUI;

    public Button returnButton;

    void Start()
    {
        CloseCanvas();
    }

    public void ShowCanvas()
    {
        SkipCanvas.gameObject.SetActive(true);
        enterDreamButtonInBarUI.gameObject.SetActive(false);
        dialogButtonInBarUI.gameObject.SetActive(false);
    }

    public void CloseCanvas()
    {
        SkipCanvas.gameObject.SetActive(false);
        enterDreamButtonInBarUI.gameObject.SetActive(true);
        dialogButtonInBarUI.gameObject.SetActive(true);
    }
}
