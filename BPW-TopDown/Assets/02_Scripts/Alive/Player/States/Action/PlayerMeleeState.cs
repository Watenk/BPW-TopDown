using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState : BaseState
{
    public GameObject MeleeCollider;
    public GameObject MeleeParticle;
    public float AttackDamage;
    public float AttackCooldown;

    private GameObject player;
    private float attackCooldownTimer;
    private DetectEnemy DetectEnemy;

    public override void OnAwake()
    {
        base.OnAwake();

        player = FindObjectOfType<Player>().gameObject;
        DetectEnemy = MeleeCollider.GetComponent<DetectEnemy>();
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0) && attackCooldownTimer <= 0)
        {
            Instantiate(MeleeParticle, gameObject.transform.position, Quaternion.identity);
            attackCooldownTimer = AttackCooldown;

            if (DetectEnemy.Target != null)
            {
                player.GetComponent<Player>().TakeKnockback(player, DetectEnemy.Target);

                DetectEnemy.Target.GetComponent<Enemy>().TakeDamage(AttackDamage);
            }
        }

        if (attackCooldownTimer >= 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    public override void OnExit()
    {

    }
}