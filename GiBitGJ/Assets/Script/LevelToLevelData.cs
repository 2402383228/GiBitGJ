using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToLevelData : MonoBehaviour
{
    public static string[] stringArray;

    /// <summary>
    /// ��һ���� 0�Ǻ�ɫ��1����ɫ��2����ɫ
    /// �ڶ����� 0����ߣ�1���ұ�
    /// </summary>

    public static Dictionary<string, int> levelToNum;

    private void Start()
    {
        stringArray = new string[3];

        //��ʼ��
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
