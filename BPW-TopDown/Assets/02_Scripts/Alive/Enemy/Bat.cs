using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public GameObject RaycastObject;
    public GameObject LineObject;
    public Color LineColor;
    public float RaycastRotationSpeed;
    public float RaycastDistance;
    public float AttackedStun;

    private LineRenderer line;
    private bool isAttacked;
    private float attackedStunTimer;
    private float raycastRotationSpeed;

    public override void OnAwake()
    {
        base.OnAwake();

        line = LineObject.GetComponent<LineRenderer>();
    }

    public override void OnStart()
    {
        base.OnStart();

        line.startColor = LineColor;
        line.endColor = LineColor;

        raycastRotationSpeed = Random.Range(RaycastRotationSpeed - 2, RaycastRotationSpeed + 2);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        line.SetPosition(0, RaycastObject.transform.position);
        line.SetPosition(1, RaycastObject.transform.position + RaycastObject.transform.right * RaycastDistance);

        //Raycast Detection
        RaycastObject.transform.Rotate(Vector3.forward * raycastRotationSpeed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(RaycastObject.transform.position, RaycastObject.transform.right, RaycastDistance);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player") && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
            {
                attackFSM.SwitchState(typeof(EnemyAttackState));
            }
            
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }

        if (attackedStunTimer >= 0 && attackFSM.currentState.GetType() != typeof(EnemyIdleState))
        {
            attackFSM.SwitchState(typeof(EnemyIdleState));
        }

        if (attackedStunTimer <= 0 && isAttacked == true && attackFSM.currentState.GetType() != typeof(EnemyAttackState))
        {
            attackFSM.SwitchState(typeof(EnemyAttackState));
        }

        if (attackedStunTimer >= 0) { attackedStunTimer -= Time.deltaTime; }
    }

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);

        isAttacked = true;
        attackedStunTimer = AttackedStun;
    }

    public override void Kill()
    {
        disable = true;
        base.Kill();
    }
}