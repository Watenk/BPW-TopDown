using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPSD;

    public float speed;
    public float rotationSpeed;

    private FSM MovementFSM;
    private FSM AttackFSM;
    private Rigidbody2D rb;
    private Animator animator;

    //Controls-----------
    //Rotation
    private bool lookingLeft;
    private bool rotateDone;
    private float currentDegrees;
    private int rotationTimer;

    //--------------------

    public void OnAwake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = playerPSD.GetComponent<Animator>();
    }

    public void OnStart()
    {
        MovementFSM = new FSM(GetComponents<BaseState>());
        MovementFSM.SwitchState("Player (PlayerIdleState)");
        AttackFSM = new FSM(GetComponents<BaseState>());
        AttackFSM.SwitchState("Player (PlayerDefaultAttackState)");
    }

    public void OnUpdate()
    {
        MovementFSM.OnUpdate();
        AttackFSM.OnUpdate();
    }

    public void OnFixedUpdate()
    {
        //Movement
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * speed);
            RotatePlayer(0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(transform.right * -1 * speed);
            RotatePlayer(180);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(transform.up * -1 * speed);
        }

        //Animation
        if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a") == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void RotatePlayer(float targetDegrees) 
    {
        if (currentDegrees < targetDegrees)
        {
            currentDegrees += rotationSpeed;
        }

        if (currentDegrees > targetDegrees)
        {
            currentDegrees -= rotationSpeed;
        }

        playerPSD.gameObject.transform.rotation = Quaternion.Euler(0, currentDegrees, 0);
    }
}