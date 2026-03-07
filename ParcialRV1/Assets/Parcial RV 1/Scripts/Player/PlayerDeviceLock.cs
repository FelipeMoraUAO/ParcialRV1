using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeviceLock : MonoBehaviour
{
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        if (playerInput.playerIndex < Gamepad.all.Count)
        {
            playerInput.SwitchCurrentControlScheme(Gamepad.all[playerInput.playerIndex]);
        }
    }
}