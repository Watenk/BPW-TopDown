using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBat : Enemy
{
    public GameObject EnemyAttackParticle;
    public float AttackDelay;
    public float Damage;
    public float AttackCooldown;
    public float MovementSpeed;
    public float TargetStopDistance;

    private Player player;
    private float attackCooldownTimer;
    private float attackDelayTimer;

    public void Awake()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Start()
    {
        attackDelayTimer = AttackDelay;
    }

    public void Update()
    {
        if (attackDelayTimer >= 0) { attackDelayTimer -= Time.deltaTime; }

        if (attackDelayTimer <= 0)
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
    }

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
    }
}
