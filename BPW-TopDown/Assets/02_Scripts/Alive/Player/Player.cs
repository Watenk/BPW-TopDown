using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : Alive
{
    public GameObject playerPSD;

    private FSM movementFSM;
    private FSM actionFSM;
    private Rigidbody2D rb;
    private Animator animator;

    //Rotation
    public float rotationSpeed;

    private float currentRotation;
    private float rotation;

    public override void OnAwake()
    {
        base.OnAwake();
        rb = GetComponent<Rigidbody2D>();
        animator = playerPSD.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        base.OnStart();
        movementFSM = new FSM(GetComponents<BaseState>());
        movementFSM.SwitchState(typeof(PlayerIdleState));

        actionFSM = new FSM(GetComponents<BaseState>());
        actionFSM.SwitchState(typeof(PlayerDefaultAttackState));
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        movementFSM.OnUpdate();
        actionFSM.OnUpdate();

        RotatePlayer();

        //Movement
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.up * Speed * Time.deltaTime * 100);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * Speed * Time.deltaTime * 100);
            rotation = 0;
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(transform.right * -1 * Speed * Time.deltaTime * 100);
            rotation = 180;
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(transform.up * -1 * Speed * Time.deltaTime * 100);
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

    private void RotatePlayer() 
    {
        if (currentRotation < rotation)
        {
            currentRotation += rotationSpeed * Time.deltaTime * 100;
        }

        if (currentRotation > rotation)
        {
            currentRotation -= rotationSpeed * Time.deltaTime * 100;
        }

        playerPSD.gameObject.transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }
}