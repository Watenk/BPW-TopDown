using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Alive
{
    protected FSM attackFSM;

    public override void OnAwake()
    {
        base.OnAwake();
        attackFSM = new FSM(GetComponents<BaseState>());
    }

    public override void OnStart()
    {
        base.OnStart();
        attackFSM.SwitchState(typeof(EnemyIdleState));
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        attackFSM.OnUpdate();
    }
}
