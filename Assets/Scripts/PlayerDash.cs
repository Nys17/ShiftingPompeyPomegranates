
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // distance to dash
    public float dashDuration = 0.5f; // duration of the dash
    public float dashCooldown = 0.5f; // time to wait before dashing again
    private float dashTimeRemaining = 0f; // time remaining for current dash
    private float dashCooldownTimeRemaining = 0f; // time remaining for dash cooldown
    private float dashSpeed = 10f; // speed to move during dash
    private Vector3 dashDirection; // direction of dash
    Rigidbody rb;
    public float dashForce = 4f;
    public Transform orientation;
    // Update is called once per frame
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dash();
        }
        
    }
  
    void Dash()
    {
        if ( dashCooldownTimeRemaining <= 0)
        {
            Debug.Log("Is Dashing");

            // calculate dash direction
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            dashDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            Debug.Log("Dash direction: " + dashDirection);
            // start dashing
            dashTimeRemaining = dashDuration;
            dashCooldownTimeRemaining = dashCooldown;
           Vector3 forcetoApply = orientation.forward * dashForce + orientation.up *dashForce;
            rb.AddForce(forcetoApply, ForceMode.Impulse);
          
            // move player by dash distance
            //transform.position += dashDirection * dashDistance;
        }

        // handle dash cooldown
        if (dashCooldownTimeRemaining > 0)
            {
                dashCooldownTimeRemaining -= Time.deltaTime;
            }

            // handle dashing
            if (dashTimeRemaining > 0)
            {
                transform.position += dashDirection * dashSpeed * Time.deltaTime;
                dashTimeRemaining -= Time.deltaTime;
            }

           
    }

    
}
