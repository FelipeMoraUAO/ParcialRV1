using UnityEngine;

public class MovableObject : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerRoleManager roleManager = collision.gameObject.GetComponent<PlayerRoleManager>();

        if (roleManager != null && roleManager.role == PlayerRole.Strong)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}