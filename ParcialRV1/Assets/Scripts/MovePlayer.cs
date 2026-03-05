using UnityEngine.InputSystem;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{
    private NS inputActions;
    private Vector2 moveInput;
    public float moveSpeed = 5f;

    private void Awake()
    {
        inputActions = new NS();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Jump.performed -= OnJump;

        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("NEW INPUT - Saltar");
    }

    private void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}