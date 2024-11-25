using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Fall : PlayerState
{
    public override void Enter()
    {
        player.Fall();
    }
    public override void LogicUpdate()
    {
        if (player.isGrounded) stateMachine.SwitchState(stateMachine.playerState_Land);
        if (player.canAirJump && input.Jump) stateMachine.SwitchState(stateMachine.playerState_AirJump);
    }

    public override void PhysicUpdate()
    {
        player.Move();
    }
}
