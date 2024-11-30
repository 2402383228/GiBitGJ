using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOfElevatorLocked : MonoBehaviour
{
    [SerializeField] private int elevatorOrder;
    void Start()
    {
        if (LevelToLevelData.elevatorAbled[elevatorOrder])
        {
            //把锁变得透明
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

            //取消锁的碰撞体
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
