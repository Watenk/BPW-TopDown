using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player Player;
    PlayerStateManager PlayerStateManager;

    private void Awake()
    {
        //References
        Player = FindObjectOfType<Player>();
        PlayerStateManager = FindObjectOfType<PlayerStateManager>();

        //Awake
        Player.OnAwake();
    }

    void Start()
    {
        PlayerStateManager.OnStart();
    }

    void Update()
    {
        PlayerStateManager.OnUpdate();
    }

    private void FixedUpdate()
    {
        Player.OnFixedUpdate();
    }
}
