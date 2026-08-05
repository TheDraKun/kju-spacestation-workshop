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
        ReadInput();
        Move();
        Rotate();
        UpdateAnimation();
    }

    private void ReadInput()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            moveInput.y += 1;

        if (Keyboard.current.sKey.isPressed)
            moveInput.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            moveInput.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            moveInput.x += 1;

        moveInput = moveInput.normalized;
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (moveInput == Vector2.zero)
            return;

        Vector3 lookDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    private void UpdateAnimation()
    {
        bool isRunning = moveInput.sqrMagnitude > 0f;
        playerAnimator.SetBool("Run", isRunning);
    }
}
