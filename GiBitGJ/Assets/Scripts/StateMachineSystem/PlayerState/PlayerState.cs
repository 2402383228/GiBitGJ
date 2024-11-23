using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : IState
{
    protected PlayerController player;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;


    public void Initialize(PlayerController player, PlayerInput input, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.input = input;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }
}
