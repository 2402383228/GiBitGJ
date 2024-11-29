using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRodController : MonoBehaviour
{
    [SerializeField] private Sprite PullRod;
    [SerializeField] private Sprite PullRodNULL;

    [Space]
    [SerializeField] private int PullRodOrder;
    [Space]
    [SerializeField] private int num1;
    [SerializeField] private int num2;
    [SerializeField] private int num3;

    void Start()
    {
        if (LevelToLevelData.elevatorAbled[PullRodOrder])
        {
            GetComponent<SpriteRenderer>().sprite = PullRodNULL;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = PullRod;
        }
    }

    void Update()
    {
        if (LevelToLevelData.elevatorAbled[PullRodOrder] && GetComponent<SpriteRenderer>().sprite == PullRod)
        {
            GetComponent<SpriteRenderer>().sprite = PullRodNULL;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSelf") && Input.GetKeyDown(KeyCode.E) && !LevelToLevelData.elevatorAbled[PullRodOrder])
        {
            LevelToLevelData.elevatorAbled[PullRodOrder] = true;
            LevelToLevelData.isWindowOpened[num1,num2,num3] = true;

            GetComponent<SpriteRenderer>().sprite = PullRodNULL;
        }
    }
}
