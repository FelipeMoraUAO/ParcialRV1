using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMove[] players;
    public Transform[] playerSpawnPoints;

    public int coinsCollected = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Reiniciando nivel");

        int count = Mathf.Min(players.Length, playerSpawnPoints.Length);

        for (int i = 0; i < count; i++)
        {
            CharacterController controller = players[i].GetComponent<CharacterController>();

            if (controller != null)
                controller.enabled = false;

            players[i].transform.position = playerSpawnPoints[i].position;

            if (controller != null)
                controller.enabled = true;
        }

        // Resetear monedas
        coinsCollected = 0;

        ResetObjects();
    }

    public void AddCoin()
    {
        coinsCollected++;
        Debug.Log("Monedas: " + coinsCollected);
    }

    void ResetObjects()
    {
        KeyItem key = FindFirstObjectByType<KeyItem>();

        if (key != null)
            key.ResetKey();

        CoinItem[] coins = FindObjectsByType<CoinItem>(FindObjectsSortMode.None);

        foreach (CoinItem coin in coins)
        {
            coin.ResetCoin();
        }
    }
}