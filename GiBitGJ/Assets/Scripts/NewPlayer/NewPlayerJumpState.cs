using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerJumpState : NewPlayerState
{
    public NewPlayerJumpState(NewPlayer _player, NewPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        if(player.isGroundDetected() && rb.velocity.y < 0f)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
