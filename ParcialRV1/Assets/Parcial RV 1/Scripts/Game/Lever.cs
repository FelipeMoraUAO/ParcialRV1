using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject[] bridges;

    public float offRotation = -15f;
    public float onRotation = 15f;

    public float rotateSpeed = 5f;

    private bool isActivated = false;

    void Update()
    {
        float target = isActivated ? onRotation : offRotation;

        Vector3 currentRotation = transform.localEulerAngles;

        float x = Mathf.LerpAngle(currentRotation.x, target, Time.deltaTime * rotateSpeed);

        transform.localEulerAngles = new Vector3(x, currentRotation.y, currentRotation.z);
    }

    public void ActivateLever()
    {
        isActivated = !isActivated;

        foreach (GameObject bridge in bridges)
        {
            bridge.SetActive(isActivated);
        }
    }
}