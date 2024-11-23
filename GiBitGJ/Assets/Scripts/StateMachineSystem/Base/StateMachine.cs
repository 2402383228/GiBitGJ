using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
}
