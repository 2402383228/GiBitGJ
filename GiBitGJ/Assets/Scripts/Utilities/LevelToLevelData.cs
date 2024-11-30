using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelToLevelData : MonoBehaviour
{
    public static string[] stringArray;
    public static bool[] boolArray;


    /// <summary>
    /// 依次为第几关，左右（0左1右），上中下三门(1,2,3)
    /// </summary>
    public static bool[,,] isDoorOpened;

    /// <summary>
    /// 依次为第几关，上下（0上1下），左中右两门(1,2,3)
    /// </summary>
    public static bool[,,] isWindowOpened;

    //这个字典用来存储关卡名字和对应的此时的位置
    public static Dictionary<string, int> levelToNum;

    //穿越密码
    //n是左右，m是上中下
    public static string nowLevel = "1level";
    public static int nwDoor_n = 0;
    public static int nwDoor_m = 0;

    public static int nwWindow_n = 0;
    public static int nwWindow_m = 0;

    public static bool passFromDoor = false;
    public static bool passFromWindow = false;
    public static bool passFromOrigin = true;

    public static Transform originPosition;

    //电梯交互
    public static bool[] elevatorAbled;

    //风车交互
    public static int windmillSum;
    public static bool[] windmillHasBeenTouch;

    //钥匙宝箱交互
    public static bool hasKey = false;
    public static bool chestHasBeenOpened = false;


    private void Start()
    {
        originPosition = GetComponentInChildren<Transform>();
        originPosition.position = new Vector3(-1f, -3.41f, 0);

        #region stringArray赋值
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
        #endregion

        #region boolArray赋值
        boolArray = new bool[10];

        boolArray[0] = false;
        boolArray[1] = false;
        boolArray[2] = false;
        boolArray[3] = false;
        boolArray[4] = false;
        boolArray[5] = false;
        boolArray[6] = false;
        boolArray[7] = false;
        boolArray[8] = false;
        boolArray[9] = false;

        #endregion

        #region levelToNum赋值
        levelToNum = new Dictionary<string, int>
        {
            {"0level",0},
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
        #endregion

        #region isDoorOpened赋值
        isDoorOpened = new bool[10, 2, 4];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    isDoorOpened[i, j, k] = false;
                }
            }
        }

        //1level
        isDoorOpened[1, 1, 1] = true;
        isDoorOpened[1, 1, 3] = true;

        //3level
        isDoorOpened[3, 0, 3] = true;
        isDoorOpened[3, 1, 2] = true;

        //4level
        isDoorOpened[4, 0, 1] = true;
        isDoorOpened[4, 0, 2] = true;

        //5level
        isDoorOpened[5, 0, 1] = true;
        isDoorOpened[5, 0, 2] = true;

        //6level
        isDoorOpened[6,0,3] = true;
        isDoorOpened[6,1,1] = true;

        //8level
        isDoorOpened[8,0,2] = true;

        //9level
        isDoorOpened[9,1,3] = true;

        #endregion

        #region isWindowOpened赋值
        isWindowOpened = new bool[10, 2, 4];

        for (int i = 0;i < 10;i++)
        {
            for (int j = 0;j < 2;j++)
            {
                for (int k = 0;k < 4;k++)
                {
                    isWindowOpened[i, j, k] = false;
                }
            }
        }

        //2level
        //isWindowOpened[2, 0, 2] = true;
        isWindowOpened[2, 0, 3] = true;

        //3level
        isWindowOpened[3, 1, 3] = true;

        //4level
        isWindowOpened[4, 1, 3] = true;

        //6level
        isWindowOpened[6, 0, 1] = true;

        //7level
        isWindowOpened[7, 1, 1] = true;
        //isWindowOpened[7, 1, 2] = true;
        //isWindowOpened[7, 1, 3] = true;

        isWindowOpened[7, 0, 3] = true;

        //8level
        //isWindowOpened[8, 0, 1] = true;
        isWindowOpened[8, 0, 3] = true;

        //isWindowOpened[8, 1, 1] = true;
        isWindowOpened[8, 1, 3] = true;

        //9level
        isWindowOpened[9, 0, 2] = true;

        #endregion

        #region elevatorAbled赋值
        elevatorAbled = new bool[9];

        for (int i = 0; i < elevatorAbled.Length; i++)
            elevatorAbled[i] = false;

        //设置特殊情况用来兼顾电梯口是否上锁
        elevatorAbled[0] = true;

        #endregion

        #region 风车赋值

        windmillSum = 0;

        windmillHasBeenTouch = new bool[5];
        for (int i = 0; i < windmillHasBeenTouch.Length; i++)
            windmillHasBeenTouch[i] = false;

        #endregion

        InitfirstLevel();
    }

    public static bool IsDoorOpened(string level, int direction, int door)
    {
        //判断是否可以通过
        int levelNum = level[0] - '0';

        return isDoorOpened[levelNum, direction, door];
    }

    public static bool IsWindowOpened(string level, int direction, int window)
    {
        //判断是否可以通过
        int levelNum = level[0] - '0';

        return isWindowOpened[levelNum, direction, window];
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }

    #region 接下来的函数用来初始化各个关卡
    public static void InitfirstLevel()
    {
        nwDoor_n = 0;
        nwDoor_m = 0;

        nwWindow_n = 0;
        nwWindow_m = 0;

        originPosition.position = new Vector3(-1f, -3.41f, 0);
        nowLevel = "1level";

        stringArray[1] = "1level";
        stringArray[2] = "2level";
        stringArray[3] = "3level";
        stringArray[4] = "4level";
        stringArray[5] = "5level";
        stringArray[6] = "6level";
        stringArray[7] = "7level";
        stringArray[8] = "8level";
        stringArray[9] = "9level";

        levelToNum["1level"] = 1;
        levelToNum["2level"] = 2;
        levelToNum["3level"] = 3;
        levelToNum["4level"] = 4;
        levelToNum["5level"] = 5;
        levelToNum["6level"] = 6;
        levelToNum["7level"] = 7;
        levelToNum["8level"] = 8;
        levelToNum["9level"] = 9;
        
        boolArray[0] = false;
        boolArray[1] = true;
        boolArray[3] = true;
        boolArray[5] = true;
    }

    public static void InitsecondLevel()
    {
        nwDoor_n = 0;
        nwDoor_m = 0;

        nwWindow_n = 0;
        nwWindow_m = 0;

        originPosition.position = new Vector3(-1f, -3.41f, 0);
        nowLevel = "1level";

        stringArray[1] = "1level";
        stringArray[2] = "2level";
        stringArray[3] = "3level";
        stringArray[4] = "4level";
        stringArray[5] = "5level";
        stringArray[6] = "6level";
        stringArray[7] = "7level";
        stringArray[8] = "8level";
        stringArray[9] = "9level";

        levelToNum["1level"] = 1;
        levelToNum["2level"] = 2;
        levelToNum["3level"] = 3;
        levelToNum["4level"] = 4;
        levelToNum["5level"] = 5;
        levelToNum["6level"] = 6;
        levelToNum["7level"] = 7;
        levelToNum["8level"] = 8;
        levelToNum["9level"] = 9;

        boolArray[0] = false;
        boolArray[1] = true;
        boolArray[3] = true;
        boolArray[5] = true;
        
        boolArray[4] = true;
        boolArray[6] = true;
        boolArray[7] = true;
    }

    public static void InitThridLevel()
    {
        nwDoor_n = 0;
        nwDoor_m = 0;

        nwWindow_n = 0;
        nwWindow_m = 0;

        originPosition.position = new Vector3(-1f, -3.41f, 0);
        nowLevel = "1level";

        stringArray[1] = "1level";
        stringArray[2] = "2level";
        stringArray[3] = "3level";
        stringArray[4] = "4level";
        stringArray[5] = "5level";
        stringArray[6] = "6level";
        stringArray[7] = "7level";
        stringArray[8] = "8level";
        stringArray[9] = "9level";

        levelToNum["1level"] = 1;
        levelToNum["2level"] = 2;
        levelToNum["3level"] = 3;
        levelToNum["4level"] = 4;
        levelToNum["5level"] = 5;
        levelToNum["6level"] = 6;
        levelToNum["7level"] = 7;
        levelToNum["8level"] = 8;
        levelToNum["9level"] = 9;

        boolArray[0] = true;
        boolArray[1] = true;
        boolArray[3] = true;
        boolArray[5] = true;

        boolArray[4] = true;
        boolArray[6] = true;
        boolArray[7] = true;

        boolArray[8] = true;
        boolArray[9] = true;
        boolArray[2] = true;
    }

    #endregion

    public static IEnumerator ExampleCoroutine()
    {
        //生成一个等待5秒的yield指令。
        yield return new WaitForSeconds(1);
    }
}
