using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttackState : BaseState
{
    public GameObject AttackCollider;
    public float AttackDamage;
    public float AttackDelay;
    public float AttackCooldown;
    public float PlayerKnockback;
    public float EnemyKnockback;

    private List<Enemy> enemysInRange = new List<Enemy>();
    private float attackSpeedTimer;

    public override void OnStart()
    {
        attackSpeedTimer = AttackCooldown;
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0) && attackSpeedTimer <= 0)
        {
            Debug.Log("Attack");
            foreach (Enemy enemy in enemysInRange)
            {
                enemy.TakeDamage(AttackDamage);
            }
            attackSpeedTimer = AttackCooldown;
        }

        if (attackSpeedTimer >= 0)
        {
            attackSpeedTimer -= Time.deltaTime;
        }
    }

    public override void OnExit()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy currentEnemy = other.gameObject.GetComponent<Enemy>();
            enemysInRange.Add(currentEnemy);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy currentEnemy = other.gameObject.GetComponent<Enemy>();
            enemysInRange.Remove(currentEnemy);
        }
    }
}
