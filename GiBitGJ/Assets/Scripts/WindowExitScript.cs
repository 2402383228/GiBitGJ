using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowExitScript : MonoBehaviour
{
    public string currentLevel;

    [Space]
    public int windowOnOrUnder;
    public int windowOrder;

    [Space]
    private int level_m;
    private int level_n;

    private string nextLevel;
    private bool canPass = false;

    private void Start()
    {
        int levelPosition = LevelToLevelData.levelToNum[currentLevel];

        //n ���У�m ����
        level_m = levelPosition % 3;
        if (level_m == 0) level_m = 3;

        level_n = (levelPosition - level_m) / 3 + 1;

        if (windowOnOrUnder == 0)
        {
            if (level_n == 1)
            {
                canPass = false;
                //���ŵ���ɫ����Ϊ��ɫ
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionOn = levelPosition + 3;
                string nextLevelOn = LevelToLevelData.stringArray[levelPositionOn];

                //Ҫ���ϱߵ����Ǵ򿪵ģ����ϱߵĹؿ��ǽ�����
                if (LevelToLevelData.IsWindowOpened(nextLevelOn, 1, windowOrder) && LevelToLevelData.boolArray[nextLevelOn[0] - '0'])
                {
                    canPass = true;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelOn;
                }
                else
                {
                    canPass = false;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                }
            }
        }
        else if (windowOnOrUnder == 1)
        {
            if (level_n == 3)
            {
                canPass = false;
                //���ŵ���ɫ����Ϊ��ɫ
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionUnder = levelPosition - 3;
                string nextLevelUnder = LevelToLevelData.stringArray[levelPositionUnder];

                //Ҫ���±ߵ����Ǵ򿪵ģ����±ߵĹؿ��ǽ�����
                if (LevelToLevelData.IsWindowOpened(nextLevelUnder, 0, windowOrder) && LevelToLevelData.boolArray[nextLevelUnder[0] - '0'])
                {
                    canPass = true;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelUnder;
                }
                else
                {
                    canPass = false;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canPass)
            return;

        if (collision.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Collision detected");

            LevelToLevelData.nowLevel = nextLevel;

            if (windowOnOrUnder == 1)
                LevelToLevelData.nwWindow_n = 0;
            else
                LevelToLevelData.nwWindow_n = 1;

            LevelToLevelData.nwWindow_m = windowOrder;

            LevelToLevelData.passFromWindow = true;
            LevelToLevelData.passFromOrigin = false;

            TransitionManager.Instance.Transition(currentLevel, nextLevel);
        }
    }
}