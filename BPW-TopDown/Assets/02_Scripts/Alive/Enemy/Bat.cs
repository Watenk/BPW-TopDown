using Mono.Cecil;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public GameObject raycastObject;
    public float raycastRotationSpeed;
    public float raycastDistance;

    public override void OnUpdate()
    {
        base.OnUpdate();

        //Raycast Detection
        raycastObject.transform.Rotate(Vector3.forward * raycastRotationSpeed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(raycastObject.transform.position, raycastObject.transform.right, raycastDistance);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player") && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
            {
                attackFSM.SwitchState(typeof(EnemyAttackState));
            }
        }
    }
}