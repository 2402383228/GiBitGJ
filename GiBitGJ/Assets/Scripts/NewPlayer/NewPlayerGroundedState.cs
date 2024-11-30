using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerGroundedState : NewPlayerState
{
    public NewPlayerGroundedState(NewPlayer _player, NewPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        //if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected())
        //    stateMachine.ChangeState(player.jumpState);

        if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState(player.activeState);
        }
    }
}