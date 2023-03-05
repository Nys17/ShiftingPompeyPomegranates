using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // player movement speed
    public float jumpForce = 5f;
    public float jumpCooldown = 0.2f; // time to wait before jumping again
    private float jumpCooldownTimeRemaining = 0f; // time remaining for jump cooldown
    public float gravity = -9.81f;
    public float gravityScale = 1;
    private CharacterController characterController;
    private Vector3 movement = Vector3.zero;
    private float verticalVelocity;
    public bool hasJumped = false;

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

        // Move the player based on the movement direction and speed
        characterController.Move(speed * Time.deltaTime * movement);

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
        if (Input.GetKey(KeyCode.Space) && jumpCooldownTimeRemaining <= 0 && characterController.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * (gravity * gravityScale));
            jumpCooldownTimeRemaining = jumpCooldown;
            hasJumped = true;
        }
        else if (characterController.isGrounded)
        {
            hasJumped = false;
        }



        verticalVelocity += gravity * gravityScale * Time.deltaTime;
        MovePlayer();
    }

    void MovePlayer()
    {
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }
}
