using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Move : PlayerState
{
    public override void LogicUpdate()
    {
        if (!input.Move) stateMachine.SwitchState(stateMachine.playerState_Idle);
        if (input.Jump) stateMachine.SwitchState(stateMachine.playerState_Jump);
    }
    public override void PhysicUpdate()
    {
        player.Move();
    }
}
