using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAttackState : BaseState
{
    public override void OnStart()
    {
        //Heal some hp points
        owner.SwitchState(typeof(PlayerMeleeState));
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}
