using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //什么颜色和什么颜色交换
    private string originalname;
    private string toname;

    public Transform originalParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalname = gameObject.name;

        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "level")
        {
            //获取交换的颜色
            toname = eventData.pointerCurrentRaycast.gameObject.name;

            //解决颜色交换问题
            int originalIndex = LevelToLevelData.levelToNum[originalname];
            int toIndex = LevelToLevelData.levelToNum[toname];

            //交换
            LevelToLevelData.Swap(ref LevelToLevelData.stringArray[originalIndex],ref LevelToLevelData.stringArray[toIndex]);
            //LevelToLevelData.Swap(ref LevelToLevelData.levelToNum[originalname], ref LevelToLevelData.levelToNum[toname]);
            int temp = originalIndex;
            LevelToLevelData.levelToNum[originalname] = toIndex;
            LevelToLevelData.levelToNum[toname] = temp;


            Transform to = eventData.pointerCurrentRaycast.gameObject.transform;

            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);

            transform.position = transform.parent.position;
            to.position = to.parent.position;

            Debug.Log("to:" + to.transform.parent.name);
        }
        else
        {
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
