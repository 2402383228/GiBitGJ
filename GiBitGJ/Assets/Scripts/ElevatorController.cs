using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    [Space]
    public bool isuping = true;

    public bool iswaiting = true;

    public float moveSpeed;

    private bool hasPlayAudio = false;

    void Update()
    {
        move();
    }

    private void move()
    {
        if(iswaiting)
            return;

        if(!hasPlayAudio)
        {
            hasPlayAudio = true;
            AudioManger.Instance.PlaySound(3);
        }

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

            hasPlayAudio = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {       
        if(other.CompareTag("PlayerSelf"))
        {
            iswaiting = false;

            if(isuping)
                other?.transform.SetParent(null);
            else
                other?.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("PlayerSelf"))
        {
            //other?.transform.SetParent(null);
        }
    }
}
