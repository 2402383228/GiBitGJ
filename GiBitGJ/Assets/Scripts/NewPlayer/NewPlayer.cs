using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : Entity
{
    public bool isBusy { get; private set; }

    [Header("Move info")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    #region States
    public NewPlayerStateMachine stateMachine { get; private set; }
    public NewPlayerIdleState idleState { get; private set; }
    public NewPlayerMoveState moveState { get; private set; }
    public NewPlayerJumpState jumpState { get; private set; }
    public NewPlayerActiveState activeState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new NewPlayerStateMachine();

        idleState = new NewPlayerIdleState(this, stateMachine, "Idle");
        moveState = new NewPlayerMoveState(this, stateMachine, "Move");
        //jumpState = new NewPlayerJumpState(this, stateMachine, "Jump");
        activeState = new NewPlayerActiveState(this, stateMachine, "Active");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }



    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();


    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }
}
