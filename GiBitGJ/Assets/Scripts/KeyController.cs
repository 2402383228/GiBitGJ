using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerSelf" && Input.GetKeyDown(KeyCode.E) && !LevelToLevelData.hasKey)
        {
            LevelToLevelData.hasKey = true;
            InventoryManager.Instance.AddItem(ItemName.OldKey);

            InventoryManager.Instance.itemData.GetItemDetails(ItemName.OldKey).isGet = true;

            key.SetActive(false);
        }
    }
}
