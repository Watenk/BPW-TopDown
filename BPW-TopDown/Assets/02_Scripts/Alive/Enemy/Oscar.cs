using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscar : Enemy
{
    public GameObject PlayerDetectRange;
    public float AttackedStun;

    private DetectPlayer detectPlayer;
    private float attackedStunTimer;

    public override void OnAwake()
    {
        base.OnAwake();

        detectPlayer = PlayerDetectRange.GetComponent<DetectPlayer>();
    }

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (attackedStunTimer <= 0 && detectPlayer.Target != null && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
        {
            attackFSM.SwitchState(typeof(EnemyAttackState));
        }

        if (attackedStunTimer >= 0 && attackFSM.currentState.GetType() != typeof(EnemyIdleState))
        {
            attackFSM.SwitchState(typeof(EnemyIdleState));
        }

        if (attackedStunTimer >= 0 ) { attackedStunTimer -= Time.deltaTime; }
    }

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);

        attackedStunTimer = AttackedStun;
    }
}