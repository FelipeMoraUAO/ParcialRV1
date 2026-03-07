using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public int correctPlayerID;

    private void OnTriggerEnter(Collider other)
    {
        PlayerRole360 player = other.GetComponent<PlayerRole360>();
        if (player != null)
        {
            if (player.playerID == correctPlayerID)
            {
                GameMang360.instance.ObjectCollected();
                Destroy(gameObject);
            }
        }
    }
}