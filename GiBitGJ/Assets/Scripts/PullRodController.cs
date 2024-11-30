using System.Collections;
using System.Collections.Generic;
using TMPro;
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


    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;
    void Start()
    {
        playerText = GetComponentInChildren<TMP_Text>();

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

        if (isPlayerInTrigger && !hasE)
        {
            playerText.text = "按E进行交互";
        }

        if (!isPlayerInTrigger)
        {
            playerText.text = "";
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            hasE = true;

            if (!LevelToLevelData.elevatorAbled[PullRodOrder])
            {
                AudioManger.Instance.PlaySound(4);

                LevelToLevelData.elevatorAbled[PullRodOrder] = true;
                LevelToLevelData.isWindowOpened[num1, num2, num3] = true;

                GetComponent<SpriteRenderer>().sprite = PullRodNULL;

                playerText.text = "某台上锁的电梯和通道被解锁了";

                StartCoroutine(DelayedTextClear(2.0f));
            }
            else
            {
                playerText.text = "这个已经解锁了";
                StartCoroutine(DelayedTextClear(2.0f));
            
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

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
