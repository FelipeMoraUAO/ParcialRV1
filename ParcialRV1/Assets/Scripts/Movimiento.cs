using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    private  NIS InputActions;

    [Header("Configuracion")]
    public float sensitivity = 0.1f;
    public Transform playerbody;

    private float xRotation = 0;

    private void Awake()
    {
        InputActions = new NIS();
    }

    private void OnEnable()
    {
        InputActions.View.Enable();
    }

    private void OnDisable()
    {
        InputActions.View.Disable();
    }

    private void Update()
    {
        rotatecamera();
    }

    private void rotatecamera()
    {
        Vector2 lookinput = InputActions.View.Look.ReadValue<Vector2>();
        
        float mouseX = lookinput.x * sensitivity;
        float mouseY = lookinput.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (playerbody != null)
        {
            playerbody.Rotate(Vector3.up * mouseX);
        }
    }
}