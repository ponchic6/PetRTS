using System;
using UnityEngine;

public class CameraMoverService : ICameraMoverService 
{
    private IInputService _inputService;
    public event Action<Vector3> OnReachCursorScreenBoundary;

    public CameraMoverService(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnCheckCursorPosition += CheckReachCursorScreenBoundary;
    }

    private void CheckReachCursorScreenBoundary(Vector2 cursorPos)
    {        
        Vector3 cameraMoveDirection = new Vector3(cursorPos.x - Screen.width / 2, 0, cursorPos.y - Screen.height / 2).normalized;
        
        if (cursorPos.x <= 0 || cursorPos.x >= Screen.width || cursorPos.y >= Screen.height || cursorPos.y <= 0) 
            OnReachCursorScreenBoundary?.Invoke(cameraMoveDirection);
    }
}