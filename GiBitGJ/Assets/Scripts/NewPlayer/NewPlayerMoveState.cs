using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class NewPlayerMoveState : NewPlayerGroundedState
{
    public NewPlayerMoveState(NewPlayer _player, NewPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
