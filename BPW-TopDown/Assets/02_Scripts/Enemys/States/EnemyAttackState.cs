using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    private GameObject player;
    public float MovementSpeed;
    public float TargetStopDistance;

    public void OnAwake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    public override void OnEnter()
    {

    }

    public override void OnUpdate()
    {
        if (Vector2.Distance(transform.position, player.transform.position) >= TargetStopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MovementSpeed * Time.deltaTime);
        }
    }

    public override void OnExit()
    {

    }
}
