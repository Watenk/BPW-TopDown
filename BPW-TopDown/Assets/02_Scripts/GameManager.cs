using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player Player;

    private void Awake()
    {
        //References
        Player = FindObjectOfType<Player>();

        //Awake
        Player.OnAwake();
    }

    void Start()
    {
        Player.OnStart();
    }

    void Update()
    {
        Player.OnUpdate();
    }

    private void FixedUpdate()
    {
        Player.OnFixedUpdate();
    }
}
