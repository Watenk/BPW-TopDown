using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpAccelerationTime;

    private Rigidbody2D rb;
    public bool touchingGround = false;
    private bool jump;
    private float jumpAccelerationTimer;
    private float horizontalInput;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("space") && touchingGround == true)
        {
            jump = true;
            touchingGround = false;
            jumpAccelerationTimer = jumpAccelerationTime;
        }
    }

    public void FixedUpdate()
    {
        //Movement
        rb.velocity = new Vector2(horizontalInput * speed, 0); 

        if (jump == true)
        {
            rb.AddForce(transform.up * (jumpForce * 10) * jumpAccelerationTimer);

            jumpAccelerationTimer -= 1;
            if (jumpAccelerationTimer < 1) { jump = false; }
        }
    }
}
