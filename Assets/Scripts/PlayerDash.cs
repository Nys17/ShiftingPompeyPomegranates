using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // distance to dash
    public float dashDuration = 0.5f; // duration of the dash
    public float dashCooldown = 0.5f; // time to wait before dashing again
    private float dashTimeRemaining = 0f; // time remaining for current dash
    private float dashCooldownTimeRemaining = 0f; // time remaining for dash cooldown
    private float speed = 5f;
    Vector3 movement = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        HandleDash();
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
            Vector3 dashDirection = movement.normalized;
            transform.position += dashDirection * speed * Time.deltaTime;
            dashTimeRemaining -= Time.deltaTime;
        }
        // check if player can dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimeRemaining <= 0 && movement.magnitude > 0)
        {
            Debug.Log("Is Dashing");
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
}
