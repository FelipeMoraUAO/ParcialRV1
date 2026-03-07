using UnityEngine;

public class GameMang360 : MonoBehaviour
{
    public static GameMang360 instance;

    public GameObject portalPanel;

    int collectedStars = 0;

    void Awake()
    {
        instance = this;
    }

    public void ObjectCollected()
    {
        collectedStars++;

        if (collectedStars == 4)
        {
            portalPanel.SetActive(true);
        }
    }
}