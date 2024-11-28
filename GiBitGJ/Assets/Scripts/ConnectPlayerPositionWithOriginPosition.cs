using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPlayerPositionWithOriginPosition : MonoBehaviour
{
    void Update()
    {
        LevelToLevelData.originPosition.position = transform.position;       
    }
}
