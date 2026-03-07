using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 2f;
    public Transform keyHoldPoint;

    private PlayerRoleManager roleManager;

    void Start()
    {
        roleManager = GetComponent<PlayerRoleManager>();
    }

    void OnInteract(InputValue value)
    {
        if (!value.isPressed) return;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
        {
            Debug.Log("Interactuando con: " + hit.collider.name);

            // -------- LLAVE --------
            KeyItem key = hit.collider.GetComponent<KeyItem>();

            if (key != null && !key.isTaken)
            {
                if (roleManager.role == PlayerRole.KeyCarrier)
                {
                    key.TakeKey(keyHoldPoint);
                }
                else
                {
                    Debug.Log("Este jugador no puede recoger la llave");
                }

                return;
            }

            // -------- PALANCA --------
            Lever lever = hit.collider.GetComponent<Lever>();

            if (lever != null)
            {
                if (roleManager.role == PlayerRole.Mechanic)
                {
                    lever.ActivateLever();
                }
                else
                {
                    Debug.Log("Solo el Mechanic puede usar la palanca");
                }

                return;
            }

            // -------- PUERTA --------
            Door door = hit.collider.GetComponent<Door>();

            if (door != null)
            {
                door.TryOpen(roleManager);
                return;
            }
        }
    }
}