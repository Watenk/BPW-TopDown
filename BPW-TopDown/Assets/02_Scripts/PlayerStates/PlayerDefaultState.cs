using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : PlayerBaseState
{
    public override void OnEnter(PlayerStateManager player)
    {
        Debug.Log("Entered default state");
        player.SwitchState(player.HealingState);
    }
}
