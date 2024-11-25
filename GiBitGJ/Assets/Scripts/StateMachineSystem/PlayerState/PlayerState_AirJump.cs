using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_AirJump : PlayerState
{
    public override void Enter()
    {
        player.AirJump();
        player.canAirJump = false;
    }

    public override void LogicUpdate()
    {
        if (player.isFall)
        {
            stateMachine.SwitchState(stateMachine.playerState_Fall);
        }
    }

    public override void PhysicUpdate()
    {
        player.Move();
    }
}
