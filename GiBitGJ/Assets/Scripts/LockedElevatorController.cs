using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedElevatorController : MonoBehaviour
{
    [SerializeField] private Sprite unlockedElevator;
    [SerializeField] private Sprite lockedElevator;
    [SerializeField] private int elevatorOrder;
    [Space]
    public float maxHeight;
    public float minHeight;
    [Space]
    public bool isuping = true;

    public bool iswaiting = true;

    public float moveSpeed;

    void Start()
    {
        if (LevelToLevelData.elevatorAbled[elevatorOrder])
        {
            GetComponent<SpriteRenderer>().sprite = unlockedElevator;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = lockedElevator;
        }
    }

    void Update()
    {
        if(LevelToLevelData.elevatorAbled[elevatorOrder] && GetComponent<SpriteRenderer>().sprite == lockedElevator)
        {
            GetComponent<SpriteRenderer>().sprite = unlockedElevator;
        }

        move();
    }

    private void move()
    {
        if (iswaiting || !LevelToLevelData.elevatorAbled[elevatorOrder])
            return;

        // Move the elevator
        transform.Translate((isuping ? Vector2.up : Vector2.down) * moveSpeed * Time.deltaTime);

        if (transform.position.y >= maxHeight)
        {
            isuping = false;
        }

        if (transform.position.y <= minHeight)
        {
            isuping = true;
            iswaiting = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!LevelToLevelData.elevatorAbled[elevatorOrder])
            return;

        if (other.CompareTag("PlayerSelf"))
        {
            iswaiting = false;

            if (isuping)
                other?.transform.SetParent(null);
            else
                other?.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSelf"))
        {
            //other?.transform.SetParent(null);
        }
    }
}
