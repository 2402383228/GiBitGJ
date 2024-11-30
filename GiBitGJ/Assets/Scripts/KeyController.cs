using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject key;

    private bool isPlayerInTrigger = false;
    private bool hasE = false;
    private TMP_Text playerText;

    private void Start()
    {
        playerText = GetComponentInChildren<TMP_Text>();
        if(LevelToLevelData.hasKey)
        {
            key.SetActive(false);
        }
    }

    private void Update()
    {
        if(LevelToLevelData.hasKey)
        {
            return;
        }

        if (isPlayerInTrigger && !hasE)
        {
            playerText.text = "��E���н���\nһ���Ͼɵ�Կ�ף�����������һ�ſ����������ĺ�Ӱ";
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
                LevelToLevelData.hasKey = true;
                InventoryManager.Instance.AddItem(ItemName.OldKey);

                InventoryManager.Instance.itemData.GetItemDetails(ItemName.OldKey).isGet = true;

                key.SetActive(false);
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
