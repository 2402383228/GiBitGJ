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
            playerText.text = "��E���н���";
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
                playerText.text = "��ʹ���ξ� ��Ҳ�޷���һ�����������ӡ�";

                StartCoroutine(DelayedTextClear(2f));
            }
            else if (LevelToLevelData.hasKey && !LevelToLevelData.chestHasBeenOpened)
            {
                AudioManger.Instance.PlaySound(3);

                playerText.text = "һ����Ƭ�������������˵ĺ�Ӱ��";

                StartCoroutine(DelayedTextClear(2f));                

                //
                LevelToLevelData.chestHasBeenOpened = true;

                InventoryManager.Instance.AddItem(ItemName.Photo);

                GetComponent<SpriteRenderer>().sprite = chestOpened;
            }
            else if(LevelToLevelData.chestHasBeenOpened)
            {
                playerText.text = "��������Ѿ����򿪹��ˡ�";

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
