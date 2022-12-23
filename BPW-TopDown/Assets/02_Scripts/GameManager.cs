using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    private CameraFollowMouse cameraFollowMouse;
    private UI UI;

    private Alive[] alives;
    private BaseState[] baseStates;

    private void Awake()
    {
        //References
        cameraFollowMouse = FindObjectOfType<CameraFollowMouse>();
        UI = FindObjectOfType<UI>();

        alives = FindObjectsOfType<Alive>();
        baseStates = FindObjectsOfType<BaseState>();

        //Awake
        foreach (Alive alive in alives) { alive.OnAwake(); }
        foreach (BaseState baseState in baseStates) { baseState.OnAwake(); }
        UI.OnAwake();
    }

    private void Start()
    {
        foreach (Alive alive in alives) { alive.OnStart(); }
        UI.OnStart();
    }

    private void Update()
    {
        cameraFollowMouse.OnUpdate();
        foreach (Alive alive in alives) { alive.OnUpdate(); }
        UI.OnUpdate();
    }

    private void FixedUpdate()
    {
        foreach (Alive alive in alives) { alive.OnFixedUpdate(); }
    }

    public void AddScore(int _amount)
    {
        score += _amount;
        UI.UpdateScore();
    }
}