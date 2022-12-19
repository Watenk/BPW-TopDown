using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public GameObject raycastObject;
    public LineRenderer line;
    public float raycastRotationSpeed;
    public float raycastDistance;

    public override void OnAwake()
    {
        base.OnAwake();

        line = GetComponent<LineRenderer>();
    }

    public override void OnStart()
    {
        base.OnStart();

        line.startColor = Color.red;
        line.endColor = Color.red;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        line.SetPosition(0, raycastObject.transform.position);
        line.SetPosition(1, raycastObject.transform.position + raycastObject.transform.right * raycastDistance);

        //Raycast Detection
        raycastObject.transform.Rotate(Vector3.forward * raycastRotationSpeed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(raycastObject.transform.position, raycastObject.transform.right, raycastDistance);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player") && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
            {
                attackFSM.SwitchState(typeof(EnemyAttackState));
            }
            
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
    }
}