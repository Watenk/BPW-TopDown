using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public int IdleTimer;

    private GameObject enemy;
    private float idleTimer;

    public override void OnStart()
    {
        enemy = this.gameObject;
    }

    public override void OnUpdate()
    {
        //Enemy idles for IdleTimer Amount
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