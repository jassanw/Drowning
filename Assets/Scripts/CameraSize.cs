using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{

    public float ScreenWidth = 6;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = 1/cam.aspect*ScreenWidth/2;
    }
}
