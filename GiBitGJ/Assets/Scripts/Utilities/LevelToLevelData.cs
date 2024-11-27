using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToLevelData : MonoBehaviour
{
    public static string[] stringArray;
    public static bool[] boolArray;

    /// <summary>
    /// 第一序列 0是红色，1是绿色，2是蓝色
    /// 第二序列 0是左边，1是右边
    /// </summary>

    public static Dictionary<string, int> levelToNum;

    public static Dictionary<string, Sprite> levelToSprite;

    [SerializeField] private Sprite[] levelSprite;

    private void Start()
    {
        stringArray = new string[10];

        //初始化
        stringArray[1] = "1level";
        stringArray[2] = "2level";
        stringArray[3] = "3level";
        stringArray[4] = "4level";
        stringArray[5] = "5level";
        stringArray[6] = "6level";
        stringArray[7] = "7level";
        stringArray[8] = "8level";
        stringArray[9] = "9level";

        levelToNum = new Dictionary<string, int>
        {
            {"1level",1},
            {"2level",2},
            {"3level",3},
            {"4level",4},
            {"5level",5},
            {"6level",6},
            {"7level",7},
            {"8level",8},
            {"9level",9}
        };

        levelToSprite = new Dictionary<string, Sprite>()
        {
            {"1level",levelSprite[1]},
            {"2level",levelSprite[2]},
            {"3level",levelSprite[3]},
            {"4level",levelSprite[4]},
            {"5level",levelSprite[5]},
            {"6level",levelSprite[6]},
            {"7level",levelSprite[7]},
            {"8level",levelSprite[8]},
            {"9level",levelSprite[9]}

        };

    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}
