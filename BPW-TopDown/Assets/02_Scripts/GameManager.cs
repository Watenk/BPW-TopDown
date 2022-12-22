using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CameraFollowMouse cameraFollowMouse;

    private Alive[] alives;
    private BaseState[] baseStates;

    private void Awake()
    {
        //References
        cameraFollowMouse = FindObjectOfType<CameraFollowMouse>();

        alives = FindObjectsOfType<Alive>();
        baseStates = FindObjectsOfType<BaseState>();

        //Awake
        foreach (Alive alive in alives) { alive.OnAwake(); }
        foreach (BaseState baseState in baseStates) { baseState.OnAwake(); }
    }

    private void Start()
    {
        foreach (Alive alive in alives) { alive.OnStart(); }
    }

    private void Update()
    {
        cameraFollowMouse.OnUpdate();
        foreach (Alive alive in alives) { alive.OnUpdate(); }
    }

    private void FixedUpdate()
    {
        foreach (Alive alive in alives) { alive.OnFixedUpdate(); }
    }
}