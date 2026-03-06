using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class move : MonoBehaviour 
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -15f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity; 
    private bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {
        //Verificar si toca el suelo
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantiene al jugador pegado al suelo
        }

        //Movimiento Horizontal
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        //Aplicar Gravedad
        velocity.y += gravity * Time.deltaTime;

        //Movimiento Vertical
        controller.Move(velocity * Time.deltaTime);
    }
}