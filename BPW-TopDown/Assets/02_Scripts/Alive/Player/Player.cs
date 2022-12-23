using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : Alive
{
    public delegate void UIUpdateHealth();
    public static event UIUpdateHealth uiUpdateHealth;
    public GameObject playerPSD;
    public GameObject DashDirection;
    public float DashSpeed;
    public float DashCooldown;
    public float Mana;

    private FSM movementFSM;
    private FSM actionFSM;
    private Rigidbody2D rb;
    private Animator animator;
    private float dashCooldownTimer;

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
        actionFSM.SwitchState(typeof(PlayerMeleeState));
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        movementFSM.OnUpdate();
        actionFSM.OnUpdate();

        RotatePlayer();

        //Inputs
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionFSM.SwitchState(typeof(PlayerMeleeState));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionFSM.SwitchState(typeof(PlayerShootState));
        }

        if (Input.GetKeyDown("h") && movementFSM.currentState.GetType() == typeof(PlayerIdleState))
        {
            //HealState
        }

        if (Input.GetKeyDown("e") && dashCooldownTimer <= 0)
        {
            //Dash
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;

            Vector3 dashDirectionPos = Camera.main.WorldToScreenPoint(DashDirection.transform.position);
            mousePos.x -= dashDirectionPos.x;
            mousePos.y -= dashDirectionPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Quaternion dashRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));

            DashDirection.transform.rotation = dashRotation;
            rb.AddForce(DashDirection.transform.up * DashSpeed * 100);

            dashCooldownTimer = DashCooldown;
        }

        if (dashCooldownTimer >= 0) { dashCooldownTimer -= Time.deltaTime; }

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

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);

        uiUpdateHealth();
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