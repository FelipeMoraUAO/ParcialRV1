using UnityEngine;

public class Door : MonoBehaviour
{
    public int totalCoinsRequired = 13;

    public void TryOpen(PlayerRoleManager roleManager)
    {
        // Solo el KeyCarrier puede intentar abrir
        if (roleManager.role != PlayerRole.KeyCarrier)
        {
            Debug.Log("Solo el KeyCarrier puede abrir la puerta");
            return;
        }

        // Verificar si tiene la llave
        KeyItem key = FindFirstObjectByType<KeyItem>();

        if (key == null || !key.isTaken)
        {
            Debug.Log("Necesitas la llave");
            return;
        }

        // Verificar monedas
        if (GameManager.instance.coinsCollected < totalCoinsRequired)
        {
            Debug.Log("Faltan monedas: " + (totalCoinsRequired - GameManager.instance.coinsCollected));
            return;
        }

        Debug.Log("Puerta abierta, nivel completado");
        gameObject.SetActive(false);
    }
}