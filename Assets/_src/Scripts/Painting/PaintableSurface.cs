using UnityEngine;

public class PaintableSurface : MonoBehaviour
{
    private const float COLOR_IMPACT_ON_PIXEL_DRAW = 0.25f;
    private const int TEXTURE_SIZE_PER_UNIT = 96;

    [SerializeField] private Material _paintableMaterial;
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private Color _emissionColor;

    private Texture2D _objectTexture;

    private void Awake() {
        _objectRenderer.material = _paintableMaterial;

        _objectTexture = new Texture2D(
            TEXTURE_SIZE_PER_UNIT * (int)transform.lossyScale.x,
            TEXTURE_SIZE_PER_UNIT * (int)transform.lossyScale.y);
        NullifyTexture();
        _objectRenderer.material.SetTexture("_PaintedTexture", _objectTexture);

        _objectRenderer.material.SetColor("_EmissionColor", _emissionColor);
    }

    public bool DrawPixelOnRaycastHit(RaycastHit hit) {
        Vector2 pixelUV = hit.textureCoord;
        Vector2 pixelPoint =
            new Vector2(pixelUV.x * _objectTexture.width, pixelUV.y * _objectTexture.height);

        //this code leads to an image like when blood splatters
        //have to change shader before giving this another chance
        //Color pixelColor = _objectTexture.GetPixel((int)pixelPoint.x, (int)pixelPoint.y);
        //float rgbValues = pixelColor.r;

        //if ((1 - rgbValues) < Mathf.Epsilon)
        //    return false;

        //rgbValues += COLOR_IMPACT_ON_PIXEL_DRAW;

        //_objectTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y, new Color(rgbValues, rgbValues, rgbValues));

        _objectTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y, Color.white);

        return true;
    }

    public void ApplyTextureChanges() {
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
