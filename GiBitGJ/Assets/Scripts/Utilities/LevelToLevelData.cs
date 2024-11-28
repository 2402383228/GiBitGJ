using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToLevelData : MonoBehaviour
{
    public static string[] stringArray;
    public static bool[] boolArray;


    /// <summary>
    /// ����Ϊ�ڼ��أ����ң�0��1�ң�������������
    /// </summary>
    public static bool[,,] isDoorOpened;

    //����ֵ������洢�ؿ����ֺͶ�Ӧ�Ĵ�ʱ��λ��
    public static Dictionary<string, int> levelToNum;

    //��Խ����
    //n�����ң�m��������
    public static string nowLevel = "1level";
    public static int nwDoor_n = 0;
    public static int nwDoor_m = 0;

    private void Start()
    {
        #region stringArray��ֵ
        stringArray = new string[10];

        //��ʼ��
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

        #region boolArray��ֵ
        boolArray = new bool[10];

        boolArray[0] = true;
        boolArray[1] = true;
        boolArray[2] = false;
        boolArray[3] = true;
        boolArray[4] = false;
        boolArray[5] = true;
        boolArray[6] = false;
        boolArray[7] = false;
        boolArray[8] = false;
        boolArray[9] = false;

        #endregion

        #region levelToNum��ֵ
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
        #endregion

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

        //5level
        isDoorOpened[5, 0, 1] = true;
        isDoorOpened[5, 0, 2] = true;
    }

    public static bool IsDoorOpened(string level, int direction, int door)
    {
        //�ж��Ƿ����ͨ��
        int levelNum = level[0] - '0';

        return isDoorOpened[levelNum, direction, door];
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}
