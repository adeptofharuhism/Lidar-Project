using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] private Transform _turretTransform;
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private float _minAngle = 25;
    [SerializeField] private float _maxAngle = -25;
    [SerializeField] private float _horizontalRotationSpeed = 60;
    [SerializeField] private float _verticalRotationSpeed = 20;

    private void Update() {
        _turretTransform.Rotate(0, InputManager.MouseVector.x * Time.deltaTime * _horizontalRotationSpeed, 0);

        float gunRotationAngle =
            _gunTransform.localRotation.eulerAngles.x +
            (InputManager.MouseVector.y * Time.deltaTime * _verticalRotationSpeed);

        if (gunRotationAngle > 180)
            gunRotationAngle -= 360;

        gunRotationAngle = Mathf.Clamp(
            gunRotationAngle,
            _maxAngle,
            _minAngle);
        _gunTransform.localRotation = Quaternion.Euler(gunRotationAngle, 0, 0);
    }
}
