using System;
using UnityEditor;
using UnityEngine;

public class InputService : IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClickDown;
    public event Action OnLeftClickUp;
    public event Action OnHoldDownMiddleButton;
    public event Action OnMiddleClickDown;

    public InputService(ITickService tickService)
    {
        tickService.OnTick += CheckCursorPosition;
        tickService.OnTick += CheckClickFire1;
        tickService.OnTick += CheckHoldDownMiddleButton;
        tickService.OnTick += CheckClickMiddleButtonDown;
    }

    public Vector2 GetCursorPos()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void CheckClickMiddleButtonDown()
    {
        if (Input.GetMouseButtonDown(2))
        {
            OnMiddleClickDown?.Invoke();
        }
    }
    private void CheckHoldDownMiddleButton()
    {
        if (Input.GetMouseButton(2))
        {
            OnHoldDownMiddleButton?.Invoke();
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