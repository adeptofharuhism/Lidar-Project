using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Transform _scanPoint;
    [Header("Scan Parameters")]
    [SerializeField] private LayerMask _scanLayerMask = new LayerMask();
    [SerializeField] private float _scanDispersion = 0;

    private Transform _cameraTransform;

    private void Start() {
        _cameraTransform = Camera.main.transform;
    }

    private void Update() {
        if (Input.GetMouseButton(0))
            PaintOnePoint();
    }

    private void PaintOnePoint() {
        if (Physics.Raycast(
            _cameraTransform.position,
            GetDispersedVector(),
            out RaycastHit hit,
            maxDistance: Mathf.Infinity,
            layerMask: _scanLayerMask)) {
            if (hit.collider.TryGetComponent(out PaintableSurface surface)) {
                surface.DrawPixelOnRaycastHit(hit);
            }
        }
    }

    private Vector3 GetDispersedVector() {
        Vector3 direction = _cameraTransform.forward;

        direction += Quaternion.AngleAxis(Random.Range(0, 360), _cameraTransform.forward) *
            _cameraTransform.up * Random.Range(0, _scanDispersion / 360);

        return direction;
    }
}
