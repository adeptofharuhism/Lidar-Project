using System;
using UnityEngine;

public class ScannerInputManager : MonoBehaviour
{
    public static event Action OnDefaultScanUsed;
    public static event Action OnMatrixScanUsed;
    public static event Action OnDecreaseScanRadius;
    public static event Action OnIncreaseScanRadius;

    private void Update() {
        if (Input.GetMouseButton(0))
            OnDefaultScanUsed?.Invoke();

        if (Input.GetMouseButton(1))
            OnMatrixScanUsed?.Invoke();

        if (Input.mouseScrollDelta.y > 0) {
            OnDecreaseScanRadius?.Invoke();
        } else if (Input.mouseScrollDelta.y < 0) {
            OnIncreaseScanRadius?.Invoke();
        }
    }
}
