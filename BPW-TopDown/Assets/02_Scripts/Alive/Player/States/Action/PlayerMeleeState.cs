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
    public float SuperAttackCost;
    public float AttackCooldown;

    private Player player;
    private float attackCooldownTimer;
    private DetectEnemy DetectEnemy;

    public override void OnAwake()
    {
        base.OnAwake();

        player = FindObjectOfType<Player>();
        DetectEnemy = MeleeCollider.GetComponent<DetectEnemy>();
    }

    public override void OnStart()
    {
    }

    public override void OnUpdate()
    {
        UpdateTimers();

        if (Input.GetMouseButtonDown(0) && attackCooldownTimer <= 0)
        {
            Attack();
        }

        if (Input.GetKeyDown("q") && player.DoIHaveEnoughMana(SuperAttackCost))
        {
            SuperAttack();
        }
    }

    public override void OnExit()
    {
    }

    private void Attack()
    {
        if (DetectEnemy.Targets.Count >= 1)
        {
            for (int i = 0; i < DetectEnemy.Targets.Count; i++)
            {
                player.TakeKnockback(player.gameObject, DetectEnemy.Targets[i]);
                DetectEnemy.Targets[i].GetComponent<Enemy>().TakeDamage(AttackDamage);
            }
        }

        Instantiate(MeleeParticle, gameObject.transform.position, Quaternion.identity);
        attackCooldownTimer = AttackCooldown;
    }

    private void SuperAttack()
    {
        player.RemoveMana(SuperAttackCost);

        if (DetectEnemy.Targets.Count >= 1)
        {
            for (int i = 0; i < DetectEnemy.Targets.Count; i++)
            {
                player.TakeKnockback(player.gameObject, DetectEnemy.Targets[i]);
                DetectEnemy.Targets[i].GetComponent<Enemy>().TakeDamage(SuperAttackDamage);
            }
        }

        Instantiate(SuperMeleeParticle, gameObject.transform.position, Quaternion.identity);
    }

    private void UpdateTimers()
    {
        if (attackCooldownTimer >= 0) { attackCooldownTimer -= Time.deltaTime; }
    }
}