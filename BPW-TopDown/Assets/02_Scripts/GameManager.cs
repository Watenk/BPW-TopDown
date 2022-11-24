using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Attack Attack;
    Player Player;

    private void Awake()
    {
        Attack = FindObjectOfType<Attack>();
        Player = FindObjectOfType<Player>();

        Attack.OnAwake();
        Player.OnAwake();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Player.OnFixedUpdate();
    }
}
