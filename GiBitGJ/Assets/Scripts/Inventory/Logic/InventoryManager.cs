using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;

    public static List<ItemName> itemList = new List<ItemName>();

    public bool getBracelet => itemData.GetItemDetails(ItemName.Bracelet).isGet;
    public bool getPhoto => itemData.GetItemDetails(ItemName.Photo).isGet;
    public bool getHairpin => itemData.GetItemDetails(ItemName.Hairpin).isGet;

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            Debug.Log(itemData.GetItemDetails(itemName).info);

            //UI��Ӧ��ʾ
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }

    void Start()
    {
        Instance.itemData.GetItemDetails(ItemName.OldKey).isGet = true;
    }

    void OnDisable()
    {
        Instance.itemData.GetItemDetails(ItemName.Bracelet).isGet = false;
        Instance.itemData.GetItemDetails(ItemName.Photo).isGet = false;
        Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet = false;
    }

}
