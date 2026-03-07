using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public int correctPlayerID;

    private void OnTriggerEnter(Collider other)
    {
        PlayerRole player = other.GetComponent<PlayerRole>();

        if (player != null)
        {
            if (player.playerID == correctPlayerID)
            {
                GameManager.instance.ObjectCollected();
                Destroy(gameObject);
            }
        }
    }
}