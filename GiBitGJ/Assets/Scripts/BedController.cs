using System.Collections;
using TMPro;
using UnityEngine;

public class BedController : MonoBehaviour
{
    [SerializeField] private Sprite bed;
    [SerializeField] private Sprite bedWithYellowLight;
    [SerializeField] private Sprite bedWithRedLight;

    [Space]
    private int NowsDay;

    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;
    void Start()
    {
        playerText = GetComponentInChildren<TMP_Text>();

        NowsDay = Gamemaneger.DayInGame;

        if (NowsDay == 1)
        {
            if (LevelToLevelData.chestHasBeenOpened)
            {
                GetComponent<SpriteRenderer>().sprite = bedWithYellowLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
        else if (NowsDay == 2)
        {
            if (LevelToLevelData.windmillSum == 4)
            {
                GetComponent<SpriteRenderer>().sprite = bedWithYellowLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
        else if (NowsDay == 3)
        {
            int sumOfElevatorAbled = 0;
            for (int i = 0; i < LevelToLevelData.elevatorAbled.Length; i++)
            {
                if (LevelToLevelData.elevatorAbled[i])
                {
                    sumOfElevatorAbled++;
                }
            }

            if (sumOfElevatorAbled == 8)
            {
                GetComponent<SpriteRenderer>().sprite = bedWithRedLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
    }

    private void Update()
    {
        if(isPlayerInTrigger && !hasE)
        {
            playerText.text = "按E进行交互";
        }

        if(!isPlayerInTrigger)
        {
            playerText.text = "";
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            hasE = true;

            AudioManger.Instance.PlaySound(0);

            if (GetComponent<SpriteRenderer>().sprite == bed)
            {

                if (NowsDay == 1)
                {
                    playerText.text = "我是忘记了什么吗，似乎有一个宝箱没有打开";
                }
                else if (NowsDay == 2)
                {
                    playerText.text = "我是忘记了什么吗，似乎还有风车没有点亮";
                }
                else if (NowsDay == 3)
                {
                    playerText.text = "我是忘记了什么吗，似乎还有电梯没有解锁";
                }

                StartCoroutine(DelayedTextClear(2f));

                

                return;
            }


            if (NowsDay == 1)
            {
                Gamemaneger.DayInGame = 2;

                LevelToLevelData.InitsecondLevel();

                TransitionManager.Instance.Transition("1level", "DialogScene");
            }
            else if (NowsDay == 2)
            {
                Gamemaneger.DayInGame = 3;

                LevelToLevelData.InitThridLevel();

                TransitionManager.Instance.Transition("1level", "DialogScene");
            }
            else if (NowsDay == 3)
            {
                //TODO:通向ed结局（hd结局为4，ed结局是5）
                Gamemaneger.DayInGame = 5;

                TransitionManager.Instance.Transition("1level", "BE");
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("PlayerSelf"))
        {
            isPlayerInTrigger = true;
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



