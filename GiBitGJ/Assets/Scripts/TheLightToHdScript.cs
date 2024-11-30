using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheLightToHdScript : MonoBehaviour
{
    [SerializeField] private Sprite Light;
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();

        if (image != null)
        {
            if (InventoryManager.Instance.itemData.GetItemDetails(ItemName.Hairpin).isGet)
            {
                image.sprite = Light;
            }
            else
            {
                image.sprite = null;
                image.color = new Color(0, 0, 0, 0); // …Ë÷√Õº∆¨Õ∏√˜
            }
        }
        else
        {
            Debug.Log("Image is null");
        }
    }
}
