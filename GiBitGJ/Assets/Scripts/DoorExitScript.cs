using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public int doorLeftOrRight;
    public int doorOrder;

    [Space]
    private int level_m;
    private int level_n;

    private string nextLevel;
    private bool canPass = false;

    private void Start()
    {
        int levelPosition = LevelToLevelData.levelToNum[currentLevel];

        //n 是行，m 是列
        level_m = levelPosition % 3;
        if (level_m == 0) level_m = 3;

        level_n = (levelPosition - level_m) / 3 + 1;

        if(doorLeftOrRight == 0)
        {
            if (level_m == 1)
            {
                canPass = false;
                //将门的颜色设置为灰色
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionLeft = levelPosition - 1;
                string nextLevelLeft = LevelToLevelData.stringArray[levelPositionLeft];

                //要求左边的门是打开的，且左边的关卡是解锁的
                if (LevelToLevelData.IsDoorOpened(nextLevelLeft, 1, doorOrder) && LevelToLevelData.boolArray[nextLevelLeft[0] - '0'])
                {
                    canPass = true;
                    //将门的颜色设置为黄色
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelLeft;
                }
                else
                {
                    canPass = false;
                    //将门的颜色设置为灰色
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                }
            }
        }
        else if (doorLeftOrRight == 1)
        {
            if (level_m == 3)
            {
                canPass = false;
                //将门的颜色设置为灰色
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionRight = levelPosition + 1;
                string nextLevelRight = LevelToLevelData.stringArray[levelPositionRight];

                //要求右边的门是打开的，且右边的关卡是解锁的
                if (LevelToLevelData.IsDoorOpened(nextLevelRight, 0, doorOrder) && LevelToLevelData.boolArray[nextLevelRight[0] - '0'])
                {
                    canPass = true;
                    //将门的颜色设置为黄色
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelRight;
                }
                else
                {
                    canPass = false;
                    //将门的颜色设置为灰色
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canPass)
            return;

        if (collision.CompareTag("PlayerSelf"))
        {
            Debug.Log("Collision detected");

            LevelToLevelData.nowLevel = nextLevel;

            if (doorLeftOrRight == 1)
                LevelToLevelData.nwDoor_n = 0;
            else
                LevelToLevelData.nwDoor_n = 1;
             
            LevelToLevelData.nwDoor_m = doorOrder;

            LevelToLevelData.passFromDoor = true;
            LevelToLevelData.passFromOrigin = false;

            TransitionManager.Instance.Transition(currentLevel, nextLevel);
        }
    }
}
