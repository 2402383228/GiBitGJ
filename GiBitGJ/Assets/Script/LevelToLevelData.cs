using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToLevelData : MonoBehaviour
{
    public static string[] stringArray;

    /// <summary>
    /// 第一序列 0是红色，1是绿色，2是蓝色
    /// 第二序列 0是左边，1是右边
    /// </summary>

    public static Dictionary<string, int> levelToNum;

    private void Start()
    {
        stringArray = new string[3];

        //初始化
        stringArray[0] = "red_level";
        stringArray[1] = "green_level";
        stringArray[2] = "blue_level";

        levelToNum = new Dictionary<string, int>
        {
            {"red_level",0},
            {"green_level",1},
            {"blue_level",2}
        };
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}
