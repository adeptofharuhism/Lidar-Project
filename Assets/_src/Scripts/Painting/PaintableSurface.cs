using UnityEngine;

public class PaintableSurface : MonoBehaviour
{
    [SerializeField] private Material _paintableMaterial;
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private int _textureSizePerUnit = 1024;
    [SerializeField] private Color _emissionColor;

    private Texture2D _objectTexture;

    private void Awake() {
        _objectRenderer.material = _paintableMaterial;

        _objectTexture = new Texture2D(
            _textureSizePerUnit * (int)transform.lossyScale.x,
            _textureSizePerUnit * (int)transform.lossyScale.y);
        NullifyTexture();
        _objectRenderer.material.SetTexture("_PaintedTexture", _objectTexture);

        _objectRenderer.material.SetColor("_EmissionColor", _emissionColor);
    }

    public void DrawPixelOnRaycastHit(RaycastHit hit) {
        Vector2 pixelUV = hit.textureCoord;
        Vector2 pixelPoint =
            new Vector2(pixelUV.x * _objectTexture.width, pixelUV.y * _objectTexture.height);

        _objectTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y, Color.white);

        _objectTexture.Apply();
    }

    private void NullifyTexture() {
        for (int i = 0; i < _objectTexture.width; i++) {
            for (int j = 0; j < _objectTexture.height; j++)
                _objectTexture.SetPixel(i, j, Color.black);
        }

        _objectTexture.Apply();
    }
}
