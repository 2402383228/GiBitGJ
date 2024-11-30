using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerStateMachine : MonoBehaviour
{
    public NewPlayerState currentState { get; private set; }

    public void Initialize(NewPlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(NewPlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
