using UnityEngine;

public class PlayerPainter : MonoBehaviour
{
    [SerializeField] private GameObject _hui;

    [SerializeField] private Transform _gunTransform;
    [SerializeField] private float _dotRadius = 0.05f;
    [SerializeField] private float _singleDotCooldown = 1;

    private float _singleDotCooldownCurrent = 0;

    private void OnEnable() {
        //InputManager.OnMouseLeftPressed += PaintSingleDot;
    }

    private void OnDisable() {
        //InputManager.OnMouseLeftPressed -= PaintSingleDot;
    }

    private void Update() {
        //SingleDotCooldown();
    }

    private void SingleDotCooldown() {
        if (_singleDotCooldownCurrent > 0)
            _singleDotCooldownCurrent -= Time.deltaTime;
    }

    private void PaintSingleDot() {
        //if (_singleDotCooldownCurrent > 0)
        //    return;

        if (Physics.Raycast(
            _gunTransform.position,
            _gunTransform.forward,
            out RaycastHit hit,
            Mathf.Infinity)) {
            if (hit.collider.TryGetComponent(out PaintableSurface surface)) {
                surface.DrawPixelOnRaycastHit(hit);

                //_singleDotCooldownCurrent = _singleDotCooldown;
            }
        }
    }
}
