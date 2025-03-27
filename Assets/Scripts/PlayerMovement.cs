using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float jumpHeight = 7f;
    [SerializeField] private float gravity = 30f;

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

        Transform cameraTransform = Camera.main.transform;
        Quaternion cameraRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        Vector3 moveDirection = cameraRotation * movement;

        // If there's any input, rotate the character to face the movement direction
        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply movement
        characterController.Move(moveDirection * speed * Time.deltaTime);

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
