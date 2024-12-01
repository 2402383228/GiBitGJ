using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private Sprite chestOpened;

    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;
    void Start()
    {
        playerText = GetComponentInChildren<TMP_Text>();

        if (LevelToLevelData.chestHasBeenOpened)
        {
            GetComponent<SpriteRenderer>().sprite = chestOpened;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = chestClosed;
        }
    }

    private void Update()
    {
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

            if (!LevelToLevelData.hasKey)
            {
                playerText.text = "即使在梦境 我也无法打开一个上锁的箱子。";

                StartCoroutine(DelayedTextClear(2f));
            }
            else if (LevelToLevelData.hasKey && !LevelToLevelData.chestHasBeenOpened)
            {
                AudioManger.Instance.PlaySound(3);

                playerText.text = "一张照片，上面是两个人的合影。";

                StartCoroutine(DelayedTextClear(2f));                

                //
                LevelToLevelData.chestHasBeenOpened = true;

                InventoryManager.Instance.AddItem(ItemName.Photo);

                GetComponent<SpriteRenderer>().sprite = chestOpened;
            }
            else if(LevelToLevelData.chestHasBeenOpened)
            {
                playerText.text = "这个箱子已经被打开过了。";

                StartCoroutine(DelayedTextClear(2f));
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
