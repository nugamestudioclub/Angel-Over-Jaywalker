using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for controlling the player's movement
 */
public class PlayerController : MonoBehaviour
{
    /*
     * Fields of the player used to manipulate and configure the movement
     */
    [SerializeField]
    private float jumpPower = 6;
    [SerializeField]
    private float moveSpeed = 15;
    private float slowDownRate = 1.1f;
    private Rigidbody2D rigidbody2d;
    private bool isGrounded;
    private bool slowingDown;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody that we will use for moving the player
        rigidbody2d = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //jump
        {
            Jump();
        }
        else if (isGrounded)
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.A)) //move left
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A)) //if stop moving while mid-air, slow down
        {
            slowingDown = true;
        }

        if (Input.GetKey(KeyCode.D)) //move right
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, rigidbody2d.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D)) // if stop moving while mid-air, slow down
        {
            slowingDown = true;
        }

        if (slowingDown)
        {
            float xVel = rigidbody2d.velocity.x;
            if (Math.Abs(xVel) / slowDownRate < 0.1)
            {
                slowingDown = false;
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            } else
            {
                rigidbody2d.velocity = new Vector2(Math.Sign(xVel) * (Math.Abs(xVel) / slowDownRate), rigidbody2d.velocity.y);
            }
        }
    }

    /*
     * Makes the player get a boost of velocity in the y direction
     */
    private void Jump()
    {
        Vector2 oldVelocity = rigidbody2d.velocity;
        Vector2 newVelocity = new Vector2(oldVelocity.x, jumpPower);
        rigidbody2d.velocity = newVelocity;
    }

    /*
     * Gets called When we stay collided with another collider
     */
    private void OnCollisionStay2D(Collision2D collision)
    {
        //saving current movement in the y direction
        float yMovement = rigidbody2d.velocity.y;

        //if the player is not moving in the y direction
        if (Mathf.Abs(yMovement) < Mathf.Epsilon)
        {
            isGrounded = true; //player is grounded
            slowingDown = false;
        }
    }

    /*
     * Gets called when we stop colliding with another collider
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        float yMovement = rigidbody2d.velocity.y;
        if (Mathf.Abs(yMovement) > Mathf.Epsilon)
        {
            isGrounded = false;
        }
    }
}
