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
        DayInGame = 3;
        isDialogFinished = new bool[4];
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            isDialogFinished[i] = true;
        }
    }
}
