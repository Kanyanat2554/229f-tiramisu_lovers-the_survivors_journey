using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 500f;
    public float jumpHeight = 2f;
    public float gravity = 30f;

    private CharacterController characterController;
    private Vector3 velocity; // Stores vertical velocity
    private bool isGrounded;

    void Start()
    {
        // Get the CharacterController component attached to the GameObject
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if character is on the ground
        isGrounded = characterController.isGrounded;

        // Reset downward velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to ensure the character stays grounded
        }

        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If there's any input, rotate the character to face the movement direction
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        // Apply movement
        characterController.Move(movement * speed * Time.deltaTime);

        // Jumping logic
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
