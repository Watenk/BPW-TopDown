using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    public GameObject EnemyAttackParticle;
    public float Damage;
    public float AttackCooldown;
    public float MovementSpeed;
    public float TargetStopDistance;

    private Player player;
    private float attackCooldownTimer;

    public override void OnAwake()
    {
        player = FindObjectOfType<Player>();
    }

    public override void OnStart()
    {
    }

    public override void OnUpdate()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= TargetStopDistance)
        {
            if (attackCooldownTimer <= 0) 
            {
                Instantiate(EnemyAttackParticle, gameObject.transform.position, Quaternion.identity);
                player.TakeDamage(Damage);
                attackCooldownTimer = AttackCooldown;
            }

            if (attackCooldownTimer >= 0) { attackCooldownTimer -= Time.deltaTime; }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MovementSpeed * Time.deltaTime);
        }

        if (attackCooldownTimer >= 0) { attackCooldownTimer -= Time.deltaTime; }
    }

    public override void OnExit()
    {

    }
}
