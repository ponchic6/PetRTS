using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMoverHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    private ICameraMoverService _cameraMoverService;
    
    [Inject]
    public void Constructor(ICameraMoverService cameraMoverService)
    {
        _cameraMoverService = cameraMoverService;
        _cameraMoverService.OnReachCursorScreenBoundary += MoveCamera;
    }
    
    public void MoveCamera(Vector3 direction)
    {
        _camera.transform.position += direction * _speed * Time.deltaTime;
    }
}