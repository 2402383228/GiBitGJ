using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    PlayerController player;
    PlayerInput input;
    public PlayerState_Idle playerState_Idle;
    public PlayerState_Move playerState_Move;
    public PlayerState_Jump playerState_Jump;
    public PlayerState_Fall playerState_Fall;
    public PlayerState_Land playerState_Land;
    public PlayerState_AirJump playerState_AirJump;

    void Awake()
    {
        player = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        playerState_Idle = new PlayerState_Idle();
        playerState_Move = new PlayerState_Move();
        playerState_Jump = new PlayerState_Jump();
        playerState_Fall = new PlayerState_Fall();
        playerState_Land = new PlayerState_Land();
        playerState_AirJump = new PlayerState_AirJump();
    }

    void OnEnable()
    {
        playerState_Idle.Initialize(player, input, this);
        playerState_Move.Initialize(player, input, this);
        playerState_Jump.Initialize(player, input, this);
        playerState_Fall.Initialize(player, input, this);
        playerState_Land.Initialize(player, input, this);
        playerState_AirJump.Initialize(player, input, this);
    }

    void Start()
    {
        SwitchOn(playerState_Idle);
    }

}
