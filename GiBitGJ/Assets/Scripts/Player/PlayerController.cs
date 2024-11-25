using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput input;
    PlayerGroundDetector detector;
    Vector2 inputDirection;
    public bool isGrounded => detector.isGrounded;
    public bool isFall => rb.velocity.y < 0 && !isGrounded;
    public float moveSpeed;
    public float jumpSpeed;
    public float airJumpSpeed;
    public bool canAirJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        detector = GetComponentInChildren<PlayerGroundDetector>();
    }

    void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public void Move()
    {
        if (input.Move) transform.localScale = new Vector3(input.playerDirection, 1f, 1f);
        SetVelocityX(input.playerDirection * moveSpeed);
    }

    public void Stop()
    {
        SetVelocityX(0f);
    }

    public void Fall()
    {
        SetVelocityY(0f);
    }

    public void Jump()
    {
        if (isGrounded) SetVelocityY(jumpSpeed);
    }

    public void AirJump()
    {
        if (!isGrounded) SetVelocityY(airJumpSpeed);
    }
}
