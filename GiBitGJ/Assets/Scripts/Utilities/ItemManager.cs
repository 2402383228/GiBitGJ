using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Canvas canvas;
    public DialogManager dialogManager;

    public Button returnButtonInDialogUI;

    public ItemName nowItem;
    public Image itemImage;
    public Button mentionButton;
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    public GameObject itemButtonPre;
    public GameObject itemGroup;

    public static int canMentionBracelet;
    public static int isMentionBracelet;

    void Start()
    {
        CloseCanvas();
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        nowItem = ItemName.None;
        UpdateItem();
        GenerateItem();
        returnButtonInDialogUI.gameObject.SetActive(false);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);

        returnButtonInDialogUI.gameObject.SetActive(true);
    }

    public void GenerateItem()
    {
        foreach (Transform child in itemGroup.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in InventoryManager.itemList)
        {
            Debug.Log(item);
            GameObject itemButton = Instantiate(itemButtonPre, itemGroup.transform);
            itemButton.GetComponent<Image>().sprite = InventoryManager.Instance.itemData.GetItemDetails(item).itemSprite;
            itemButton.GetComponent<Button>().onClick.AddListener(
            delegate
            {
                OnItemClick(item);
            });
        }
    }

    public void UpdateItem()
    {
        ShowImage();
        ShowName();
        ShowDescription();
        if (nowItem == ItemName.None || InventoryManager.Instance.itemData.GetItemDetails(nowItem).isGet == true)
        {
            mentionButton.gameObject.SetActive(false);
        }
        else
        {
            mentionButton.gameObject.SetActive(true);
        }
    }

    void ShowImage()
    {
        itemImage.sprite = InventoryManager.Instance.itemData.GetItemDetails(nowItem).itemSprite;
    }

    void ShowName()
    {
        itemName.text = InventoryManager.Instance.itemData.GetItemDetails(nowItem).name;
    }

    void ShowDescription()
    {
        itemDescription.text = InventoryManager.Instance.itemData.GetItemDetails(nowItem).info;
    }

    public void OnItemClick(ItemName item)
    {
        nowItem = item;
        UpdateItem();
    }

    public void OnMentionItem()
    {
        InventoryManager.Instance.itemData.GetItemDetails(nowItem).isGet = true;
        CloseCanvas();
        dialogManager.CloseSelection();
        dialogManager.ShowTargetDialog(18);
    }
}
