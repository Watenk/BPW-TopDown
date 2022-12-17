using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : BaseState
{
    public GameObject[] points;
    public float MovementSpeed;
    public float TargetStopDistance;

    private GameObject currentTarget;
    private int totalTargets;
    private int currentTargetIndex;

    public override void OnAwake()
    {
        totalTargets = points.Length;
    }

    public override void OnStart()
    {
        currentTarget = points[currentTargetIndex];
    }

    public override void OnUpdate()
    {
        //Patrol between points
        if (Vector2.Distance(transform.position, currentTarget.transform.position)  >= TargetStopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            currentTargetIndex += 1;
            if (currentTargetIndex == totalTargets)
            {
                currentTargetIndex = 0;
            }

            owner.SwitchState(typeof(EnemyIdleState));
        }
    }

    public override void OnExit()
    {

    }
}