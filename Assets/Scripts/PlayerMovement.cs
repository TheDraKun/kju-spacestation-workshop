using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("References")]
    [SerializeField] private Animator playerAnimator;

    private CharacterController controller;
    private Vector2 moveInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Mission 1 - Take Control
        // 1. Read keyboard input.
        // 2. Move the player.
        // 3. Rotate the player toward the movement direction.
        // 4. Update the running animation.
    }

    private void ReadInput()
    {
        // Mission 1 - Read WASD input into moveInput.
    }

    private void Move()
    {
        // Mission 1 - Convert moveInput into a world-space movement direction.
    }

    private void Rotate()
    {
        // Mission 1 - Rotate the player toward the current movement direction.
    }

    private void UpdateAnimation()
    {
        // Mission 1 - Update the Animator based on whether the player is moving.
    }
}
