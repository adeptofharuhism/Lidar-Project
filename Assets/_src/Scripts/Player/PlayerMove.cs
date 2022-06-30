using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update() {
        RotatePlayer();
        MovePlayer();
    }

    private void RotatePlayer() {
        float rotationAngle = _rotationSpeed * InputManager.MovementVector.x;

        transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
    }

    private void MovePlayer() {
        Vector3 velocityVector = transform.forward * _movementSpeed * InputManager.MovementVector.y;

        _playerRb.velocity = new Vector3(
            velocityVector.x,
            _playerRb.velocity.y,
            velocityVector.z);
    }
}
