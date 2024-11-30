using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;

    private void Start()
    {
        //
        playerText = GetComponentInChildren<TMP_Text>();

        int levelPosition = LevelToLevelData.levelToNum[currentLevel];

        //n ���У�m ����
        level_m = levelPosition % 3;
        if (level_m == 0) level_m = 3;

        level_n = (levelPosition - level_m) / 3 + 1;

        if(doorLeftOrRight == 0)
        {
            if (level_m == 1)
            {
                canPass = false;
                //���ŵ���ɫ����Ϊ��ɫ
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionLeft = levelPosition - 1;
                string nextLevelLeft = LevelToLevelData.stringArray[levelPositionLeft];

                //Ҫ����ߵ����Ǵ򿪵ģ�����ߵĹؿ��ǽ�����
                if (LevelToLevelData.IsDoorOpened(nextLevelLeft, 1, doorOrder) && LevelToLevelData.boolArray[nextLevelLeft[0] - '0'])
                {
                    canPass = true;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelLeft;
                }
                else
                {
                    canPass = false;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                }
            }
        }
        else if (doorLeftOrRight == 1)
        {
            if (level_m == 3)
            {
                canPass = false;
                //���ŵ���ɫ����Ϊ��ɫ
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                int levelPositionRight = levelPosition + 1;
                string nextLevelRight = LevelToLevelData.stringArray[levelPositionRight];

                //Ҫ���ұߵ����Ǵ򿪵ģ����ұߵĹؿ��ǽ�����
                if (LevelToLevelData.IsDoorOpened(nextLevelRight, 0, doorOrder) && LevelToLevelData.boolArray[nextLevelRight[0] - '0'])
                {
                    canPass = true;
                    //���ŵ���ɫ����Ϊ��ɫ
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

                    nextLevel = nextLevelRight;
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

    private void Update()
    {
        if(isPlayerInTrigger && !canPass)
        {
            playerText.text = "������ƺ�ͨ��һƬ�ڰ���Ҳ����Ӧ��Ϊ�Լ���һ��ͨ���𴦵��š�";
        }
        else
        {
            playerText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSelf"))
        {
            isPlayerInTrigger = true;
        }

        if (!canPass)
            return;

        if (collision.CompareTag("PlayerSelf"))
        {
            Debug.Log("Collision detected");

            AudioManger.Instance.PlaySound(5);

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

    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (_collision.CompareTag("PlayerSelf"))
        {
            isPlayerInTrigger = false;
        }
    }

    private IEnumerator DelayedTextClear(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerText.text = "";

        hasE = false;
    }
}
