using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPSD;

    public float speed;
    public float slowdown;
    public float jumpForce;
    public float jumpAccelerationTime;

    private Rigidbody2D rb;
    private Animator animator;

    //Controls-----------
    //Movement
    private bool lookingLeft;
    private bool aKey;
    private bool dKey;

    //Jump
    public bool touchingGround = false;
    private bool wKey;
    private float jumpAccelerationTimer;
    //--------------------

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = playerPSD.GetComponent<Animator>();
    }

    public void Update()
    {
        //Inputs
        if (Input.GetKey("a")) { aKey = true; }
        else { aKey = false; }

        if (Input.GetKey("d")) { dKey = true; }
        else { dKey = false; }

        if (Input.GetKeyDown("w") && touchingGround == true)
        {
            wKey = true;
            touchingGround = false;
            jumpAccelerationTimer = jumpAccelerationTime;
        }
    }

    public void FixedUpdate()
    {
        //Movement
        if (aKey == true)
        {
            rb.velocity = transform.right * -1 * speed;
            if (lookingLeft == false)
            {
                playerPSD.gameObject.transform.Rotate(0f, 180f, 0f);
                lookingLeft = true;
            }
        }

        if (dKey == true)
        {
            rb.velocity = transform.right * speed;
            if (lookingLeft == true)
            {
                playerPSD.gameObject.transform.Rotate(0f, 180f, 0f);
                lookingLeft = false;
            }
        }

        //Jump
        if (wKey == true)
        {
            rb.AddForce(transform.up * (jumpForce * 10) * jumpAccelerationTimer);

            jumpAccelerationTimer -= 1;
            if (jumpAccelerationTimer < 1) { wKey = false; }
        }

        //Animation
        if (aKey || dKey == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
