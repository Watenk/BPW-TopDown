using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealingState : BaseState
{
    public override void OnStart()
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
