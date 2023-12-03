using System;
using UnityEngine;

public class CameraMoverService : ICameraMoverService
{
    private readonly IInputService _inputService;

    private Vector2 _pastCursorScreenPos;
    private Vector2 _currentCursorScreenPos;
    public event Action<Vector3> OnReachCursorScreenBoundary;
    public event Action<Vector3> OnChangeCursorPosWithHoldDownMiddleButton;

    public CameraMoverService(IInputService inputService)
    {
        _inputService = inputService;
        _inputService.OnCheckCursorPosition += CheckReachCursorScreenBoundary;
        _inputService.OnMiddleClickDown += SetPastCursorPosToCurrentCursorPos;
        _inputService.OnHoldDownMiddleButton += CheckCursorDeltaPositionChange;
    }

    private void CheckReachCursorScreenBoundary(Vector2 cursorPos)
    {
        Vector3 cameraMoveDirection =
            new Vector3(cursorPos.x - Screen.width / 2, 0, cursorPos.y - Screen.height / 2).normalized;

        if (cursorPos.x <= 0 || cursorPos.x >= Screen.width || cursorPos.y >= Screen.height || cursorPos.y <= 0)
            OnReachCursorScreenBoundary?.Invoke(cameraMoveDirection);
    }

    private void CheckCursorDeltaPositionChange()
    {
        _currentCursorScreenPos = _inputService.GetCursorPos();
        if (_pastCursorScreenPos != _currentCursorScreenPos)
        {
            Vector3 delta = new Vector3(_currentCursorScreenPos.x - _pastCursorScreenPos.x, 0,
                _currentCursorScreenPos.y - _pastCursorScreenPos.y);
            OnChangeCursorPosWithHoldDownMiddleButton?.Invoke(-delta);
        }

        _pastCursorScreenPos = _currentCursorScreenPos;
    }

    private void SetPastCursorPosToCurrentCursorPos()
    {
        _currentCursorScreenPos = _inputService.GetCursorPos();
        _pastCursorScreenPos = _currentCursorScreenPos;
    }
}