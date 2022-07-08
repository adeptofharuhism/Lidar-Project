using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Transform _scanPoint;
    [SerializeField] private int _raycastsPerFixedUpdate = 10;
    [Header("Scan Parameters")]
    [SerializeField] private LayerMask _scanLayerMask = new LayerMask();
    [SerializeField] private float _scanDispersion = 0;

    private Transform _cameraTransform;

    private List<PaintableSurface> _contactedSurfacesPerFrame = new List<PaintableSurface>();

    private void Start() {
        _cameraTransform = Camera.main.transform;
    }

    private void Update() {
        if (Input.GetMouseButton(0))
            PaintSpray();
    }

    private void PaintSpray() {
        for (int i = 0; i < _raycastsPerFixedUpdate; i++)
            PaintOnePoint();

        ApplyChangesOnSurfaces();
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

                if (!_contactedSurfacesPerFrame.Contains(surface))
                    _contactedSurfacesPerFrame.Add(surface);
            }
        }
    }

    private void ApplyChangesOnSurfaces() {
        foreach(var surface in _contactedSurfacesPerFrame) {
            surface.ApplyTextureChanges();
        }

        _contactedSurfacesPerFrame.Clear();
    }

    private Vector3 GetDispersedVector() {
        Vector3 direction = _cameraTransform.forward;

        direction += Quaternion.AngleAxis(Random.Range(0, 360), _cameraTransform.forward) *
            _cameraTransform.up * Random.Range(0, _scanDispersion / 360);

        return direction;
    }
}
