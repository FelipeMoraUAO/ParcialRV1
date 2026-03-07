using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void CollectCoin()
    {
        GameManager.instance.AddCoin();
        gameObject.SetActive(false);
    }

    public void ResetCoin()
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
    }
}