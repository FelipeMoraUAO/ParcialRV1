using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            GameManager.instance.RestartLevel();
        }
    }
}