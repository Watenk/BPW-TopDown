using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState : BaseState
{
    public GameObject MeleeCollider;
    public GameObject MeleeParticle;
    public GameObject SuperMeleeParticle;
    public float AttackDamage;
    public float SuperAttackDamage;
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
            if (DetectEnemy.Targets.Count >= 1)
            {
                for (int i = 0; i < DetectEnemy.Targets.Count; i++)
                {
                    player.GetComponent<Player>().TakeKnockback(player, DetectEnemy.Targets[i]);
                    DetectEnemy.Targets[i].GetComponent<Enemy>().TakeDamage(AttackDamage);
                }
            }

            Instantiate(MeleeParticle, gameObject.transform.position, Quaternion.identity);
            attackCooldownTimer = AttackCooldown;
        }

        if (Input.GetKeyDown("q"))
        {
            if (DetectEnemy.Targets.Count >= 1)
            {
                for (int i = 0; i < DetectEnemy.Targets.Count; i++)
                {
                    player.GetComponent<Player>().TakeKnockback(player, DetectEnemy.Targets[i]);
                    DetectEnemy.Targets[i].GetComponent<Enemy>().TakeDamage(SuperAttackDamage);
                }
            }

            Instantiate(SuperMeleeParticle, gameObject.transform.position, Quaternion.identity);
        }

        if (attackCooldownTimer >= 0) { attackCooldownTimer -= Time.deltaTime; }
    }

    public override void OnExit()
    {

    }
}