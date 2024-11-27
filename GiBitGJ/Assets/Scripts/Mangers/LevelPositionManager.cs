using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPositionManager : MonoBehaviour
{
    private string objectName;
    private string parentName;

    private void Start()
    {
        objectName = gameObject.name;
        parentName = LevelToLevelData.levelToNum[objectName].ToString();

        transform.SetParent(GameObject.Find(parentName).transform);
        transform.position = transform.parent.position;
    }
}
