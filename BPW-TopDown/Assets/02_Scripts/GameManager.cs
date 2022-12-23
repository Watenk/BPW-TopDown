using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        UI.OnAwake();
        foreach (Alive alive in alives) { alive.OnAwake(); }
        foreach (BaseState baseState in baseStates) { baseState.OnAwake(); }
    }

    private void Start()
    {
        UI.OnStart();
        foreach (Alive alive in alives) { alive.OnStart(); }
    }

    private void Update()
    {
        cameraFollowMouse.OnUpdate();
        UI.OnUpdate();
        foreach (Alive alive in alives) { alive.OnUpdate(); }
    }

    private void FixedUpdate()
    {
        foreach (Alive alive in alives) { alive.OnFixedUpdate(); }
    }
}