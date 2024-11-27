using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;
    Vector2 inputDirection;
    public float playerDirection;
    public bool Move => !(playerDirection == 0f);
    public bool Jump;
    public bool stopJump;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputDirection = new Vector2();
    }

    void OnEnable()
    {
        inputActions.Enable();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        inputDirection = inputActions.GamePlay.Move.ReadValue<Vector2>();
        if (inputDirection.x > 0) playerDirection = 1;
        else if (inputDirection.x < 0) playerDirection = -1;
        else playerDirection = 0;
        Jump = inputActions.GamePlay.Jump.WasPerformedThisFrame();
        stopJump = inputActions.GamePlay.Jump.WasReleasedThisFrame();
    }
}
