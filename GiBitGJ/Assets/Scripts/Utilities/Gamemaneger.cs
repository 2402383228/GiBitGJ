using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    public static int DayInGame;

    public static bool[] isDialogFinished;

    void Awake()
    {
        DayInGame = 1;
        isDialogFinished = new bool[10];
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            isDialogFinished[i] = false;
        }
    }
}
