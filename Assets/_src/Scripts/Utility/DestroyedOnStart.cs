using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedOnStart : MonoBehaviour
{
    private void Start() {
        Destroy(gameObject);
    }
}
