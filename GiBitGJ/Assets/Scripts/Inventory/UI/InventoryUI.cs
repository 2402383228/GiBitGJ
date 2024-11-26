using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public SlotUI slotUI;

    public Button leftButton, rightButton;

    public int currentIndex;    //��ʾ����Ʒ�����ݿ��Ӧ�ı��

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEnvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEnvent;
    }

    private void OnUpdateUIEnvent(ItemDetails itemDetails, int index)
    {
       if(itemDetails == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            slotUI.SetItem(itemDetails);
            currentIndex = index;
        }
    }
}
