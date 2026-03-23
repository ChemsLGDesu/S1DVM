using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 moveInput;
    public InputSystem_Actions inputSystem;
    public float speed = 5f;

    private void OnEnable()
    {
        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();

        inputSystem.Player.Move.started += Movement;
        inputSystem.Player.Move.performed += Movement;
        inputSystem.Player.Move.canceled += Movement;
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
