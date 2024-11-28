using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginEntranceScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public GameObject playerPerfab;
    private void Awake()
    {
        if (LevelToLevelData.nowLevel == currentLevel && LevelToLevelData.passFromOrigin)
        {
            LevelToLevelData.passFromOrigin = false;

            Instantiate(playerPerfab, LevelToLevelData.originPosition.position, Quaternion.identity);
        }
    }
}
