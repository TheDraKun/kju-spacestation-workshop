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
        // Get the CharacterController attached to the Player.
    }

    private void Update()
    {
        // Read input first, then update the Player every frame.
        ReadInput();
        Move();
        Rotate();
        UpdateAnimation();
    }

    private void ReadInput()
    {
        // Start with no movement input.

        // Read W and S for forward/backward movement.

        // Read A and D for left/right movement.

        // Normalize the input so diagonal movement is not faster.
    }

    private void Move()
    {
        // Convert our 2D input into a direction in the 3D world.

        // Move using the CharacterController.
        // Remember to make movement frame-rate independent.
    }

    private void Rotate()
    {
        // Do nothing if the Player is standing still.

        // Convert the movement input into a direction to face.

        // Calculate the target rotation.

        // Smoothly rotate the Player toward that direction.
    }

    private void UpdateAnimation()
    {
        // Check whether the Player is moving.

        // Update the Animator's "Run" parameter.
    }
}
