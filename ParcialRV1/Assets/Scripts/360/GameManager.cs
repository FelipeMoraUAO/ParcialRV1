using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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