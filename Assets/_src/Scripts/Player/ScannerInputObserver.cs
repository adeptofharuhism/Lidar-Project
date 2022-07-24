using CodeBase.Services;
using CodeBase.Services.Input;
using System;
using UnityEngine;

namespace CodeBase.Scripts.Player
{
    public class ScannerInputObserver : MonoBehaviour
    {
        public event Action MouseLeftHeld;
        public event Action MouseRightHeld;
        public event Action ButtonEHeld;
        public event Action ButtonQHeld;

        private IInputService _inputs;

        private void Awake() {
            _inputs = AllServices.Container.Single<IInputService>();
        }

        private void Update() {
            if (_inputs.LeftButtonObserver.IsPressed)
                MouseLeftHeld?.Invoke();

            if (_inputs.RightButtonObserver.IsPressed)
                MouseRightHeld?.Invoke();

            if (_inputs.ButtonEObserver.IsPressed)
                ButtonEHeld?.Invoke();

            if (_inputs.ButtonQObserver.IsPressed)
                ButtonQHeld?.Invoke();
        }
    }
}