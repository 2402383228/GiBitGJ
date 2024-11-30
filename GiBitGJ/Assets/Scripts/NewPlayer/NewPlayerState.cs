using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerState
{
    protected NewPlayerStateMachine stateMachine;
    protected NewPlayer player;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public NewPlayerState(NewPlayer _player, NewPlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        rb = player.rb;
        triggerCalled = false;

        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
