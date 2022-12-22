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

    public override void OnAwake()
    {
        totalTargets = points.Length;
    }

    public override void OnStart()
    {
        currentTarget = points[Random.Range(0, totalTargets)];
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
            currentTarget = points[Random.Range(0, totalTargets)];

            owner.SwitchState(typeof(EnemyIdleState));
        }
    }

    public override void OnExit()
    {

    }
}