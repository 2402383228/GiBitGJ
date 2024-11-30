using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TheLightToHdScript : MonoBehaviour
{
    [SerializeField] private Sprite Light;
    void Start()
    {
        if(InventoryManager.Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet)
        {
            GetComponent<Image>().sprite = Light;
        }
        else
        {
            GetComponent<Image>().sprite = null;
        }
    }
}
