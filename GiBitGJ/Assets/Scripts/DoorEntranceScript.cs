using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntranceScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public int doorLeftOrRight;
    public int doorOrder;

    [Space]
    public GameObject playerPerfab;
    private void Start()
    {
        if(LevelToLevelData.nowLevel == currentLevel && LevelToLevelData.nwDoor_n == doorLeftOrRight && LevelToLevelData.nwDoor_m == doorOrder && LevelToLevelData.passFromDoor)
        {
            LevelToLevelData.passFromDoor = false;
            LevelToLevelData.passFromOrigin = false;
            LevelToLevelData.passFromWindow = false;
            Instantiate(playerPerfab, transform.position, Quaternion.identity);
        }
    }
}
