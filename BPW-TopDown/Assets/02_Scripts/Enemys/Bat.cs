using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public GameObject raycastObject;
    public float rotationSpeed;
    public float raycastDistance;
    public float AttackTime;

    private float attackTime;

    public override void OnUpdate()
    {
        base.OnUpdate();

        raycastObject.transform.Rotate(Vector3.forward* rotationSpeed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(raycastObject.transform.position, raycastObject.transform.right, raycastDistance);

        attackTime -= 1 * Time.deltaTime;

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player") && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
            {
                attackFSM.SwitchState(typeof(EnemyAttackState));
                attackTime = AttackTime;
            }
        }

        if (attackTime <= 0 && attackFSM.currentState.GetType() == typeof(EnemyAttackState)) 
        {
            attackFSM.SwitchState(typeof(EnemyIdleState));
        }
    }
}
