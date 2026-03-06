using UnityEngine;
using UnityEngine.InputSystem; 
public class playerSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;

    // Esta función se ejecuta cada vez que un mando/teclado se une
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        // Obtenemos el número del jugador (0, 1, 2 o 3)
        int index = playerInput.playerIndex;

        // Si tenemos un punto de spawn para ese índice, movemos al jugador ahí
        if (index < spawnPoints.Length)
        {
            // Desactivamos el CharacterController un milisegundo para evitar conflictos de posición
            CharacterController cc = playerInput.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            playerInput.transform.position = spawnPoints[index].position;
            playerInput.transform.rotation = spawnPoints[index].rotation;

            if (cc != null) cc.enabled = true;
        }
    }
}
