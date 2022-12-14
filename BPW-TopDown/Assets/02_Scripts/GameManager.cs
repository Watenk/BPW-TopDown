using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player Player;
    private Enemy[] enemys;

    private EnemyPatrolState[] enemyPatrolStates;
    private EnemyAttackState[] enemyAttackStates;

    private void Awake()
    {
        //References
        Player = FindObjectOfType<Player>();
        enemys = FindObjectsOfType<Enemy>();

        enemyPatrolStates = FindObjectsOfType<EnemyPatrolState>();
        enemyAttackStates = FindObjectsOfType<EnemyAttackState>();

        //Awake
        Player.OnAwake();
        foreach (Enemy enemy in enemys) { enemy.OnAwake(); }

        foreach (EnemyPatrolState enemyPatrolState in enemyPatrolStates) { enemyPatrolState.OnAwake(); }
        foreach (EnemyAttackState enemyAttackState in enemyAttackStates) { enemyAttackState.OnAwake(); }
    }

    void Start()
    {
        Player.OnStart();
        foreach (Enemy enemy in enemys) { enemy.OnStart(); }
    }

    void Update()
    {
        Player.OnUpdate();
        foreach (Enemy enemy in enemys) { enemy.OnUpdate(); }
    }

    private void FixedUpdate()
    {
        Player.OnFixedUpdate();
    }
}