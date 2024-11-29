using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Gamemaneger.DayInGame = 3;
        Gamemaneger.isDialogFinished[1] = true;
        Gamemaneger.isDialogFinished[2] = true;
        Gamemaneger.isDialogFinished[3] = true;
        InventoryManager.Instance.AddItem(ItemName.Bracelet);
        InventoryManager.Instance.AddItem(ItemName.Photo);
        InventoryManager.Instance.AddItem(ItemName.Hairpin);
    }
}
