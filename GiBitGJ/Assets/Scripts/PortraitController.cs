using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    [SerializeField] private Sprite portrait;

    [Space]
    [SerializeField] private string level;
    void Start()
    {
        if(LevelToLevelData.nowLevel == level)
        {
            GetComponent<Image>().sprite = portrait;

            //并将其颜色设置为不透明
            Color color = GetComponent<Image>().color;
            color.a = 1;
            GetComponent<Image>().color = color;
        }
        else
        {
            GetComponent<Image>().sprite = null;

            //并将其颜色设置为透明
            Color color = GetComponent<Image>().color;
            color.a = 0;
            GetComponent<Image>().color = color;
        }
    }

}
