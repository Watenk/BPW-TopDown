using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : BaseState
{
    public GameObject[] points;

    private NavMeshAgent agent;
    private int targetAmount;
    private GameObject target;

    public void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override void OnEnter()
    {
        targetAmount = points.Length;
        Debug.Log(targetAmount);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}