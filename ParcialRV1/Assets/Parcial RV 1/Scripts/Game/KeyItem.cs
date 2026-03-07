using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public bool isTaken = false;

    private Vector3 startPosition;
    private Transform startParent;

    void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void TakeKey(Transform holdPoint)
    {
        isTaken = true;

        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void ResetKey()
    {
        isTaken = false;

        transform.SetParent(startParent);
        transform.position = startPosition;

        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}