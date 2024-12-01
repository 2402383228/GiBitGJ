using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public string Mod;
    void Update()
    {
        // 检测是否按下键盘上的 E 键
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnGameQuit();
        }
    }

    void OnGameQuit()
    {
        if (Mod == "None")
        {
            return;
        }
        else if (Mod == "BE")
        {
            TransitionManager.Instance.Transition("BE", "Credit");
        }
        else if (Mod == "HE")
        {
            TransitionManager.Instance.Transition("HE", "Credit");
        }
    }
}
