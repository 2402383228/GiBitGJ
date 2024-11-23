using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Jump : PlayerState
{
    public override void Enter()
    {
        player.Jump();
    }

    public override void LogicUpdate()
    {
        if (player.isGrounded) stateMachine.SwitchState(stateMachine.playerState_Idle);
    }

    public override void PhysicUpdate()
    {
        player.Move();
    }
}
