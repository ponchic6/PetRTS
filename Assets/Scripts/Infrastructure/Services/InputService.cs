using System;
using UnityEditor;
using UnityEngine;

public class InputService : IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClickDown;
    public event Action OnLeftClickUp;
    public event Action OnRightClickDown;
    public event Action OnRightClickUp;
    public event Action OnHoldDownMiddleButton;
    public event Action OnMiddleClickDown;
    public event Action OnMiddleClickUp;

    private bool _isHoldDownMiddleButton;

    public InputService(ITickService tickService)
    {
        tickService.OnTick += CheckCursorPosition;

        tickService.OnTick += CheckClickFire1;
        tickService.OnTick += CheckClickFire2;

        tickService.OnTick += CheckClickMiddleButtonDown;
        tickService.OnTick += CheckClickMiddleButtonUp;
        tickService.OnTick += CheckHoldDownMiddleButton;
    }

    private void CheckClickFire2()
    {
        if (Input.GetMouseButtonDown(1))
            OnRightClickDown?.Invoke();

        if (Input.GetMouseButtonUp(1))
            OnRightClickUp?.Invoke();
    }

    public Vector2 GetCursorPos()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void CheckHoldDownMiddleButton()
    {
        if (_isHoldDownMiddleButton)
            OnHoldDownMiddleButton?.Invoke();
        ;
    }

    private void CheckClickMiddleButtonUp()
    {
        if (Input.GetMouseButtonUp(2))
        {
            OnMiddleClickUp?.Invoke();
            _isHoldDownMiddleButton = false;
        }
    }

    private void CheckClickMiddleButtonDown()
    {
        if (Input.GetMouseButtonDown(2))
        {
            OnMiddleClickDown?.Invoke();
            _isHoldDownMiddleButton = true;
        }
    }

    private void CheckClickFire1()
    {
        if (Input.GetMouseButtonDown(0))
            OnLeftClickDown?.Invoke();

        if (Input.GetMouseButtonUp(0))
            OnLeftClickUp?.Invoke();
    }

    private void CheckCursorPosition()
    {
        Vector2 cursorPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        OnCheckCursorPosition?.Invoke(cursorPos);
    }
}