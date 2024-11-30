using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLightToHdScript : MonoBehaviour
{
    [SerializeField] private Sprite Light;
    void Start()
    {
        if(InventoryManager.Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet)
        {
            GetComponent<SpriteRenderer>().sprite = Light;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
