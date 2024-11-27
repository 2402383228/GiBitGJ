using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPositionManager : MonoBehaviour
{
    private string objectName;
    private string parentName;

    public Sprite falseSprite;

    private void Start()
    {
        objectName = gameObject.name;
        parentName = LevelToLevelData.levelToNum[objectName].ToString();

        transform.SetParent(GameObject.Find(parentName).transform);
        transform.position = transform.parent.position;

        if(LevelToLevelData.boolArray[objectName[0] - '0'] == false)
        {
            GetComponent<Image>().sprite = falseSprite;
        }
    }
}
