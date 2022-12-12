using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealingState : BaseState
{
    public override void OnEnter()
    {
        //Heal some hp points
        owner.SwitchState(typeof(PlayerDefaultAttackState));
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}
