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
        if (input.stopJump || player.isFall)
        {
            stateMachine.SwitchState(stateMachine.playerState_Fall);
        }
    }

    public override void PhysicUpdate()
    {
        player.Move();
    }
}
