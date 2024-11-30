using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int setDay;
    void Start()
    {
        Gamemaneger.DayInGame = setDay;
        if (setDay == 2) LevelToLevelData.InitsecondLevel();
        if (setDay == 3) LevelToLevelData.InitThridLevel();
        if (setDay > 1) InventoryManager.Instance.AddItem(ItemName.Bracelet);
        if (setDay > 1) InventoryManager.Instance.AddItem(ItemName.Photo);
        if (setDay > 2) InventoryManager.Instance.AddItem(ItemName.Hairpin);
        if (setDay > 1) InventoryManager.Instance.AddItem(ItemName.OldKey);
    }

    void Update()
    {
        Debug.Log(Gamemaneger.DayInGame);
    }

    void OnDisable()
    {
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Bracelet).isGet = false;
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Photo).isGet = false;
        InventoryManager.Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet = false;
    }
}
