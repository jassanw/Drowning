using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DespawnController : MonoBehaviour
{
    private Camera mainCamera;
    private void Start() {
        mainCamera = FindObjectOfType<Camera>();
    }
    private void OnBecameInvisible() {
        if (gameObject.transform.position.y <
                mainCamera.transform.position.y + mainCamera.orthographicSize) {
            Destroy(gameObject);
        }
    }
}
