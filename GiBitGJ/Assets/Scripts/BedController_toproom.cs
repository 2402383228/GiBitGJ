using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedController_toproom : MonoBehaviour
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

        if (NowsDay == 3)
        {
            int sumOfElevatorAbled = 0;
            for (int i = 1; i < LevelToLevelData.elevatorAbled.Length; i++)
            {
                if (LevelToLevelData.elevatorAbled[i])
                {
                    sumOfElevatorAbled++;
                }
            }

            if (sumOfElevatorAbled >= 8)
            {
                GetComponent<SpriteRenderer>().sprite = bedWithYellowLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && !hasE)
        {
            playerText.text = "��E���н���";
        }

        if (!isPlayerInTrigger)
        {
            playerText.text = "";
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            hasE = true;

            AudioManger.Instance.PlaySound(0);

            if (GetComponent<SpriteRenderer>().sprite == bed)
            {

                if (NowsDay == 3)
                {
                    playerText.text = "����������ʲô���ƺ����е���û�н���";
                }

                StartCoroutine(DelayedTextClear(2f));

                return;
            }


            else if (NowsDay == 3)
            {
                //TODO:ͨ��ed��֣�hd���Ϊ4��ed�����5��
                Gamemaneger.DayInGame = 4;

                TransitionManager.Instance.Transition("0level", "DialogScene");
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
