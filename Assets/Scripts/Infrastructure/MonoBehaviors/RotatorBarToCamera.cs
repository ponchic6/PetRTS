using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorBarToCamera : MonoBehaviour
{
    private Camera _mainCamera;
    private void Update()
    {
        _mainCamera = Camera.main;
        
        transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.back,
            _mainCamera.transform.rotation * Vector3.down);
    }
}
