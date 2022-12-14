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

    protected FSM attackFSM;

    public virtual void OnAwake()
    {
        attackFSM = new FSM(GetComponents<BaseState>());
    }

    public virtual void OnStart()
    {
        attackFSM.SwitchState(typeof(EnemyIdleState));
    }

    public virtual void OnUpdate()
    {
        attackFSM.OnUpdate();
    }

    public virtual void TakeDamage()
    {
        
    }
}
