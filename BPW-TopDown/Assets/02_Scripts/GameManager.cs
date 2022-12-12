using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player Player;
    Bat Bat;

    EnemyPatrolState EnemyPatrolState;

    private void Awake()
    {
        //References
        Player = FindObjectOfType<Player>();
        Bat = FindObjectOfType<Bat>();

        EnemyPatrolState = FindObjectOfType<EnemyPatrolState>();

        //Awake
        Player.OnAwake();
        Bat.OnAwake();

        EnemyPatrolState.OnAwake();
    }

    void Start()
    {
        Player.OnStart();
        Bat.OnStart();
    }

    void Update()
    {
        Player.OnUpdate();
        Bat.OnUpdate();
    }

    private void FixedUpdate()
    {
        Player.OnFixedUpdate();
    }
}
