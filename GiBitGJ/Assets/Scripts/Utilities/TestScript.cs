using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int day;
    void Start()
    {
        Gamemaneger.DayInGame = day;

        if (day == 2) LevelToLevelData.InitsecondLevel();
        if (day == 3) LevelToLevelData.InitThridLevel();

        if (day > 1) InventoryManager.Instance.AddItem(ItemName.Bracelet);
        if (day > 1) InventoryManager.Instance.AddItem(ItemName.Photo);
        if (day > 2) InventoryManager.Instance.AddItem(ItemName.Hairpin);
        if (day > 1) InventoryManager.Instance.AddItem(ItemName.OldKey);
    }
}
