using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        player.Stop();
        player.canAirJump = true;
    }

    public override void LogicUpdate()
    {
        if (input.Move) stateMachine.SwitchState(stateMachine.playerState_Move);
        if (input.Jump) stateMachine.SwitchState(stateMachine.playerState_Jump);
    }
}
