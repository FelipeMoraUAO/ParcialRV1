using UnityEngine;
using System.Collections;

public class PressureButton : MonoBehaviour
{
    public GameObject[] bridges;
    public float deactivateDelay = 3f;

    private Coroutine deactivateCoroutine;

    void OnTriggerEnter(Collider other)
    {
        PlayerRoleManager roleManager = other.GetComponent<PlayerRoleManager>();

        if (roleManager != null && roleManager.role == PlayerRole.Mechanic)
        {
            foreach (GameObject bridge in bridges)
            {
                bridge.SetActive(true);
            }

            if (deactivateCoroutine != null)
                StopCoroutine(deactivateCoroutine);
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerRoleManager roleManager = other.GetComponent<PlayerRoleManager>();

        if (roleManager != null && roleManager.role == PlayerRole.Mechanic)
        {
            deactivateCoroutine = StartCoroutine(DeactivateBridge());
        }
    }

    IEnumerator DeactivateBridge()
    {
        yield return new WaitForSeconds(deactivateDelay);

        foreach (GameObject bridge in bridges)
        {
            bridge.SetActive(false);
        }
    }
}