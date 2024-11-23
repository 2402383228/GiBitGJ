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

    void Awake()
    {
        player = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        playerState_Idle = new PlayerState_Idle();
        playerState_Move = new PlayerState_Move();
        playerState_Jump = new PlayerState_Jump();
    }

    void OnEnable()
    {
        playerState_Idle.Initialize(player, input, this);
        playerState_Move.Initialize(player, input, this);
        playerState_Jump.Initialize(player, input, this);
    }

    void Start()
    {
        SwitchOn(playerState_Idle);
    }

}
