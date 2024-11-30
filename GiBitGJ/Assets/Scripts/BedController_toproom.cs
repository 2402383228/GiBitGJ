using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController_toproom : MonoBehaviour
{
    [SerializeField] private Sprite bed;
    [SerializeField] private Sprite bedWithYellowLight;
    [SerializeField] private Sprite bedWithRedLight;

    [Space]
    private int NowsDay;

    void Start()
    {
        NowsDay = Gamemaneger.DayInGame;

        if (NowsDay == 3)
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
                GetComponent<SpriteRenderer>().sprite = bedWithYellowLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GetComponent<SpriteRenderer>().sprite == bed)
            return;

        if (collision.CompareTag("PlayerSelf") && Input.GetKeyDown(KeyCode.E))
        {
            if (NowsDay == 3)
            {
                //TODO:通向ed结局（hd结局为4，ed结局是5）
                Gamemaneger.DayInGame = 4;

                TransitionManager.Instance.Transition("0level", "DialogScene");
            }
        }
    }
}
