using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float gravity = -15f;
    public float jumpForce = 2f;

    public Transform cameraTransform;
    public float sensibility = 0.2f;
    public float minLimit = -80f;
    public float maxLimit = 80f;
    public float gamepadSensibility = 100f;

    private float currentRotationY;
    private CharacterController characterController;
    private PlayerInput playerInput;

    private Vector2 movement;
    private Vector2 look;
    private Vector3 velocity;
    private bool isGrounded;

    public string colorJugador;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void Update()
    {
        Movement();
        Look();
    }

    private void Look()
    {
        if (cameraTransform == null)
        {
            return;
        }

        float sX, sY;


        if (playerInput.currentControlScheme == "Gamepad")
        {

            sX = look.x * gamepadSensibility * Time.deltaTime;
            sY = look.y * gamepadSensibility * Time.deltaTime;
        }
        else
        {

            sX = look.x * sensibility;
            sY = look.y * sensibility;
        }

        currentRotationY = Mathf.Clamp(currentRotationY - sY, minLimit, maxLimit);
        cameraTransform.localRotation = Quaternion.Euler(currentRotationY, 0, 0);

        transform.Rotate(Vector3.up * sX);
    }

    private void Movement()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        characterController.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}