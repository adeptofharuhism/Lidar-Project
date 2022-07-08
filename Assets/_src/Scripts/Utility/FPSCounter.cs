using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsText;

    void Update()
    {
        _fpsText.text = ((int)(1f / Time.deltaTime)).ToString();
    }
}
