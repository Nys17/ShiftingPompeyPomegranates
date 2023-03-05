using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f; // player movement speed
    public float jumpForce = 5f;
    public float jumpCooldown = 0.2f; // time to wait before jumping again
    private float jumpCooldownTimeRemaining = 0f; // time remaining for jump cooldown
    public float gravity = -9.81f;
    public float gravityScale = 1;
    private CharacterController characterController;
    private Vector3 movement = Vector3.zero;
    private float verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the WASD keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction based on input
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        // Move the player based on the movement direction and speed
        characterController.Move(movement * speed * Time.deltaTime);

        HandleJump();
    }

    void HandleJump()
    {
        // Handle jump cooldown
        if (jumpCooldownTimeRemaining > 0)
        {
            jumpCooldownTimeRemaining -= Time.deltaTime;
        }

        // Check if player can jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpCooldownTimeRemaining <= 0)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpForce * -2f * (gravity * gravityScale));
            }
        verticalVelocity += gravity * gravityScale * Time.deltaTime;
        MovePlayer();
    }

    void MovePlayer()
    {
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }

}
