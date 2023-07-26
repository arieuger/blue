using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    
    private GameInputs input;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
        input = new GameInputs();
        input.Player.Enable();
        input.Player.Jump.performed += JumpPerformed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vInput = input.Player.Movement.ReadValue<Vector2>();
        Vector3 direction = new Vector3(vInput.x, 0, 0);
        player.UpdateMovement(direction);
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        player.Jump();
    }
}
