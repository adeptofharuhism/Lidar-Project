using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public static event Action OnMouseLeftPressed;
    public static event Action OnMouseRightPressed;

    private static Vector2 _movementVector = Vector2.zero;
    private static Vector2 _mouseVector = Vector2.zero;

    private Controls _controls;

    public static Vector2 MovementVector => _movementVector;
    public static Vector2 MouseVector => _mouseVector;

    private void Awake() {
        _controls = new Controls();
    }

    private void OnEnable() {
        _controls.Player.MovePlayer.performed += SetMovementVector;
        _controls.Player.MovePlayer.canceled += SetMovementVector;
        _controls.Player.MoveMouse.performed += SetMouseInput;

        _controls.Enable();
    }

    private void OnDisable() {
        _controls.Disable();

        _controls.Player.MovePlayer.performed -= SetMovementVector;
        _controls.Player.MovePlayer.canceled -= SetMovementVector;
        _controls.Player.MoveMouse.performed -= SetMouseInput;
    }

    private void Update() {
        if (Mouse.current.leftButton.isPressed)
            OnMouseLeftPressed?.Invoke();

        if (Mouse.current.rightButton.isPressed)
            OnMouseRightPressed?.Invoke();
    }

    private void SetMovementVector(InputAction.CallbackContext ctx) {
        _movementVector = ctx.ReadValue<Vector2>();
    }

    private void SetMouseInput(InputAction.CallbackContext ctx) {
        _mouseVector = ctx.ReadValue<Vector2>();
    }
}
