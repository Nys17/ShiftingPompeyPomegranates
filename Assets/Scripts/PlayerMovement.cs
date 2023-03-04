using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // player movement speed
    public float dashDistance = 5f; // distance to dash
    public float dashDuration = 0.2f; // duration of the dash
    public float dashCooldown = 1f; // time to wait before dashing again
    private float dashTimeRemaining = 0f; // time remaining for current dash
    private float dashCooldownTimeRemaining = 0f; // time remaining for dash cooldown
    public float jumpForce = 5f;
    public float jumpCooldown = 0.2f; // time to wait before jumping again
    private float jumpCooldownTimeRemaining = 0f; // time remaining for jump cooldown
    public float gravity = -9.81f;
    float velocity;
    Vector3 movement = new Vector3(0f, 0f, 0f);
    // Update is called once per frame
    void Update()
    {
        // get input from the WASD keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // calculate the movement direction based on input


        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1f, 0f, 0f);
        }
        movement = movement.normalized;

        // move the player based on the movement direction and speed
        transform.position += movement * speed * Time.deltaTime;
        HandleDash();
        HandleJump();
    }
    void HandleDash()
    {
        // handle dash cooldown
        if (dashCooldownTimeRemaining > 0)
        {
            dashCooldownTimeRemaining -= Time.deltaTime;
        }

        // handle dashing
        if (dashTimeRemaining > 0)
        {
            Vector3 dashDirection = transform.forward;
            transform.position += dashDirection * speed * Time.deltaTime;
            dashTimeRemaining -= Time.deltaTime;
        }
        // check if player can dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimeRemaining <= 0 && movement.magnitude > 0)
        {
            // start dashing
            dashTimeRemaining = dashDuration;
            dashCooldownTimeRemaining = dashCooldown;

            // calculate dash direction
            Vector3 dashDirection = movement.normalized;
            dashDirection.y = 0f;

            // move player by dash distance
            transform.position += dashDirection * dashDistance;
        }
    }
    void HandleJump()
    {
        if (jumpCooldownTimeRemaining > 0)
        {
            jumpCooldownTimeRemaining -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCooldownTimeRemaining <= 0)
        {
            // apply jump force to the player
            GetComponent<Rigidbody>().velocity += new Vector3(0f, jumpForce, 0f);

            // start jump cooldown
            jumpCooldownTimeRemaining = jumpCooldown;
        }
    }

}