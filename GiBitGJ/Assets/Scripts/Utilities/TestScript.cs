using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Gamemaneger.DayInGame = 1;
        InventoryManager.Instance.AddItem(ItemName.Bracelet);
        InventoryManager.Instance.AddItem(ItemName.Photo);
        InventoryManager.Instance.AddItem(ItemName.Hairpin);
        InventoryManager.Instance.AddItem(ItemName.OldKey);
    }

    void Update()
    {
        Debug.Log(Gamemaneger.DayInGame);
    }
}
