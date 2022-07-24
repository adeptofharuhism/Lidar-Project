using System;
using UnityEngine.InputSystem;

namespace CodeBase.Services.Input
{
    public class InputButtonHoldObserver
    {
        public event Action Pressed;
        public event Action Released;

        private bool _isPressed = false;
        private InputAction _inputAction;

        public bool IsPressed => _isPressed;

        public InputButtonHoldObserver(InputAction inputAction) {
            _inputAction = inputAction;
        }

        public void Enable() {
            _inputAction.started += HandlePressed;
            _inputAction.canceled += HandleReleased;
        }

        public void Disable() {
            _inputAction.started -= HandlePressed;
            _inputAction.canceled -= HandleReleased;
        }

        private void HandlePressed(InputAction.CallbackContext ctx) {
            _isPressed = true;
            Pressed?.Invoke();
        }

        private void HandleReleased(InputAction.CallbackContext ctx) {
            _isPressed = false;
            Released?.Invoke();
        }
    }
}