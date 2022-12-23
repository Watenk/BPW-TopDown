using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public int IdleTimer;

    private float idleTimer;

    public override void OnStart()
    {
    }

    public override void OnUpdate()
    {
        idleTimer += 1 * Time.deltaTime;

        if (idleTimer >= IdleTimer)
        {
            idleTimer = 0;

            owner.SwitchState(typeof(EnemyPatrolState));
        }
    }

    public override void OnExit()
    {
    }
}