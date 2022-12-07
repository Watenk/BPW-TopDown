using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerDefaultState DefaultState = new PlayerDefaultState();
    public PlayerHealingState HealingState = new PlayerHealingState();

    public void OnStart()
    {
        currentState = DefaultState;
        currentState?.OnEnter(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.OnEnter(this);
    }

    public void OnUpdate()
    {
        //currentState?.OnUpdate(this);
    }

    public void OnExit()
    {
        currentState?.OnExit(this);
    }
}
