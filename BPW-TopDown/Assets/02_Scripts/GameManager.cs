using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private Alive[] alives;
    private BaseState[] baseStates;

    private void Awake()
    {
        //References
        alives = FindObjectsOfType<Alive>();
        baseStates = FindObjectsOfType<BaseState>();

        //Awake
        foreach (Alive alive in alives) { alive.OnAwake(); }
        foreach (BaseState baseState in baseStates) { baseState.OnAwake(); }
    }

    void Start()
    {
        foreach (Alive alive in alives) { alive.OnStart(); }
    }

    void Update()
    {
        foreach (Alive alive in alives) { alive.OnUpdate(); }
    }

    private void FixedUpdate()
    {
        foreach (Alive alive in alives) { alive.OnFixedUpdate(); }
    }
}