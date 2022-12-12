using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public float AttackDamage;
    public float AttackSpeed;
    public float MovementSpeed;

    private FSM attackFSM;
    private NavMeshAgent agent;

    public virtual void OnAwake()
    {
        attackFSM = new FSM(GetComponents<BaseState>());
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void OnStart()
    {
        attackFSM.SwitchState(typeof(EnemyIdleState));

        agent.speed = MovementSpeed;
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void TakeDamage()
    {
        
    }
}
