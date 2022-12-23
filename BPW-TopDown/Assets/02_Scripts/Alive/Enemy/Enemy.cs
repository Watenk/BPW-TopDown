using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Alive
{
    public GameObject Heart;
    public GameObject Mana;
    public int HeartDropChance;
    public int ManaDropChance;
    public int DropOffset;
    public FSM attackFSM;

    protected bool disable;

    public override void OnAwake()
    {
        base.OnAwake();
        attackFSM = new FSM(GetComponents<BaseState>());
    }

    public override void OnStart()
    {
        base.OnStart();
        attackFSM.SwitchState(typeof(EnemyIdleState));
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!disable) { attackFSM.OnUpdate(); }
    }

    public override void Kill()
    {
        if (Random.Range(0, 10) <= HeartDropChance / 10)
        {
            Vector2 randomVector = new Vector2(gameObject.transform.position.x + Random.Range(-DropOffset, DropOffset), gameObject.transform.position.y + Random.Range(-DropOffset, DropOffset));
            Instantiate(Heart, randomVector, Quaternion.identity);
        }

        if (Random.Range(0, 10) <= ManaDropChance / 10)
        {
            Vector2 randomVector = new Vector2(gameObject.transform.position.x + Random.Range(-DropOffset, DropOffset), gameObject.transform.position.y + Random.Range(-DropOffset, DropOffset));
            Instantiate(Mana, randomVector, Quaternion.identity);
        }

        base.Kill();
    }
}