using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class NewPlayerIdleState : NewPlayerGroundedState
{
    public NewPlayerIdleState(NewPlayer _player, NewPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
            stateMachine.ChangeState(player.moveState);
    }
}
