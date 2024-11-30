using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagerIndream : MonoBehaviour
{
    public Canvas canvas;

    public ItemName nowItem;
    public Image itemImage;
    public Button ObserveButton;
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    public GameObject itemButtonPre;
    public GameObject itemGroup;

    public Sprite photoBackLocked;
    public Sprite photoBackColored;

    void Start()
    {
        PlayMusic();
        CloseCanvas();
    }

    public void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        nowItem = ItemName.None;
        UpdateItem();
        GenerateItem();
        // returnButtonInDialogUI.gameObject.SetActive(false);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);

        // returnButtonInDialogUI.gameObject.SetActive(true);
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
        if (nowItem == ItemName.Photo)
        {
            ObserveButton.gameObject.SetActive(true);
        }
        else
        {
            ObserveButton.gameObject.SetActive(false);
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
        if (InventoryManager.Instance.itemData.GetItemDetails(nowItem).isGet)
        {
            itemDescription.text = InventoryManager.Instance.itemData.GetItemDetails(nowItem).detailInfo;
        }
        else
        {
            itemDescription.text = InventoryManager.Instance.itemData.GetItemDetails(nowItem).info;
        }
    }

    public void OnItemClick(ItemName item)
    {
        nowItem = item;
        UpdateItem();
    }

    public void OnObserveClick()
    {
        if (InventoryManager.Instance.itemData.GetItemDetails(nowItem).isGet)
        {
            itemImage.sprite = photoBackColored;
        }
        else
        {
            itemImage.sprite = photoBackLocked;
        }
    }

    public void PlayMusic()
    {
        if (Gamemaneger.DayInGame == 3)
        {
            AudioManger.Instance.PlayBackgroundMusic(3);
        }
        else
        {
            AudioManger.Instance.PlayBackgroundMusic(2);
        }
    }

    public void PlayButtonSound()
    {
        AudioManger.Instance.PlaySoundEffect();
    }
}
