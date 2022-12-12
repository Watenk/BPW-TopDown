using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public override void OnEnter()
    {
        owner.SwitchState(typeof(EnemyPatrolState));
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}