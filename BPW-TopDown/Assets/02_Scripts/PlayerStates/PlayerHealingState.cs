using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealingState : PlayerBaseState
{
    public override void OnEnter(PlayerStateManager player)
    {
        Debug.Log("Entered Healing state");
    }
}
