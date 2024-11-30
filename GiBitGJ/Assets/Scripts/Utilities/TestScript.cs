using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Gamemaneger.DayInGame = 1;

        /*
        InventoryManager.Instance.AddItem(ItemName.Bracelet);
        InventoryManager.Instance.AddItem(ItemName.Photo);
        InventoryManager.Instance.AddItem(ItemName.Hairpin);
        InventoryManager.Instance.AddItem(ItemName.OldKey);
        */
    }

    void Update()
    {
        //Debug.Log(Gamemaneger.DayInGame);
    }

    void OnDisable()
    {   /*
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Bracelet).isGet = false;
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Photo).isGet = false;
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet = false;
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.OldKey).isGet = false;
        */
    }
}
