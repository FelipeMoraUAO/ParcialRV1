using UnityEngine;
using UnityEngine.InputSystem;

public class Look360 : MonoBehaviour

{
    private NIS InputActions;

    [Header("Configuracion")]
    public float sensitivity = 0.1f;
    public Transform playerbody;

    private float xRotation = 0;
    private Vector2 lookinput;

    private void Awake()
    {
        InputActions = new NIS();
    }

    private void OnEnable()
    {
        InputActions.View.Enable();

        InputActions.View.Look.performed += OnLook;
        InputActions.View.Look.canceled += OnLook;
    }

    private void OnDisable()
    {
        InputActions.View.Look.performed -= OnLook;
        InputActions.View.Look.canceled -= OnLook;

        InputActions.View.Disable();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookinput = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        Rotatecamera();
    }

    private void Rotatecamera()
    {

        float mouseX = lookinput.x * sensitivity;
        float mouseY = lookinput.y * sensitivity;

        //Rotacion vertical (arriba /abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotacion horizontal (izquierda /derecha)
        if (playerbody != null)
        {
            playerbody.Rotate(Vector3.up * mouseX);
        }
    }
}