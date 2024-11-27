using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntranceScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public int doorLeftOrRight;
    public int doorOrder;
    void Start()
    {
        if(LevelToLevelData.nowLevel == currentLevel && LevelToLevelData.nwDoor_n == doorLeftOrRight && LevelToLevelData.nwDoor_m == doorOrder)
        {
            PlayerPositionManager.instance.transform.position = transform.position;
        }
    }
}
