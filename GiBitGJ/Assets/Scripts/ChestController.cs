using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private Sprite chestOpened;
    void Start()
    {
        if(LevelToLevelData.chestHasBeenOpened)
        {
            GetComponent<SpriteRenderer>().sprite = chestOpened;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = chestClosed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerSelf" && Input.GetKeyDown(KeyCode.E) && LevelToLevelData.hasKey && !LevelToLevelData.chestHasBeenOpened)
        {
            LevelToLevelData.chestHasBeenOpened = true;
            GetComponent<SpriteRenderer>().sprite = chestOpened;
        }
    }
}
