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
            //�������͸��
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

            //ȡ��������ײ��
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
