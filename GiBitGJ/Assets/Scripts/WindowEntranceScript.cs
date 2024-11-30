using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEntranceScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public int windowOnOrUnder;
    public int windowOrder;

    [Space]
    public GameObject playerPerfab;
    private void Start()
    {
        if (LevelToLevelData.nowLevel == currentLevel && LevelToLevelData.nwWindow_n == windowOnOrUnder && LevelToLevelData.nwWindow_m == windowOrder && LevelToLevelData.passFromWindow)
        {
            LevelToLevelData.passFromDoor = false;
            LevelToLevelData.passFromOrigin = false;
            LevelToLevelData.passFromWindow = false;
            Instantiate(playerPerfab, transform.position, Quaternion.identity);
        }
    }
}
