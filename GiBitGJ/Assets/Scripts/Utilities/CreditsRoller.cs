using UnityEngine;
using UnityEngine.UI;

public class CreditsRoller : MonoBehaviour
{
    public float scrollSpeed = 50f; // 滚动速度
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 向上滚动
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // 可选：检查滚动是否结束
        if (rectTransform.anchoredPosition.y > rectTransform.sizeDelta.y)
        {
            OnCreditsEnd();
        }
    }

    void OnCreditsEnd()
    {
        TransitionManager.Instance.Transition("Credit", "StartScene");
    }
}
