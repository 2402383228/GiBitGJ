using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class BedController : MonoBehaviour
{
    [SerializeField] private Sprite bed;
    [SerializeField] private Sprite bedWithYellowLight;
    [SerializeField] private Sprite bedWithRedLight;

    [Space]
    private int NowsDay;

    void Start()
    {
        if(NowsDay == 1)
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
        else if(NowsDay == 2)
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
        else if(NowsDay == 3)
        {
            int sumOfElevatorAbled = 0;
            for (int i = 0; i < LevelToLevelData.elevatorAbled.Length; i++)
            {
                if (LevelToLevelData.elevatorAbled[i])
                {
                    sumOfElevatorAbled++;
                }
            }

            if(sumOfElevatorAbled == 8)
            {
                GetComponent<SpriteRenderer>().sprite = bedWithRedLight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = bed;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(GetComponent<SpriteRenderer>().sprite == bed)
            return;

        if (collision.CompareTag("PlayerSelf") && Input.GetKeyDown(KeyCode.E))
        {
            if(NowsDay == 1)
            {

            }
            else if(NowsDay == 2)
            {

            }
            else if(NowsDay == 3)
            {

            }
        }
    }
}
