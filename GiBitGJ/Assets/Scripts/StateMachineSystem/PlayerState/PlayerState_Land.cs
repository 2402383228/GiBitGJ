using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Land : PlayerState
{
    public override void LogicUpdate()
    {
        stateMachine.SwitchState(stateMachine.playerState_Idle);
    }
}
