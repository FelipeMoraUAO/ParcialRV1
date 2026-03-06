using UnityEngine;
using UnityEngine.InputSystem; 
public class playerSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;

    public Material[] materialesColores;

    private string[] nombresColores = { "Morado", "Rojo", "Rosado", "Verde" };

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        int index = playerInput.playerIndex;

        if (index < spawnPoints.Length)
        {
            CharacterController cc = playerInput.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;
            playerInput.transform.position = spawnPoints[index].position;
            if (cc != null) cc.enabled = true;
        }

        move pc = playerInput.GetComponent<move>();

        if (pc != null && index < nombresColores.Length)
        {
            pc.colorJugador = nombresColores[index];

            if (index < materialesColores.Length)
            {
                Material materialAAsignar = materialesColores[index];

                Transform skinnedMeshesContainer = playerInput.transform.Find("SkinnedMeshes");

                if (skinnedMeshesContainer != null)
                {
                    SkinnedMeshRenderer[] renderers = skinnedMeshesContainer.GetComponentsInChildren<SkinnedMeshRenderer>();

                    foreach (SkinnedMeshRenderer smr in renderers)
                    {
                        smr.material = materialAAsignar;
                    }
                }
                else
                {
                    Debug.LogError("No se encontró el objeto 'SkinnedMeshes'en el prefab");
                }
            }
        }
    }
}
