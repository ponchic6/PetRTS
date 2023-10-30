using System;
using UnityEngine;

public class InputService : IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClick;

    public InputService(ITickService tickService)
    {
        tickService.OnTick += CheckCursorPosition;
        tickService.OnTick += CheckClickFire1;
    }

    public Vector2 GetCursorPos()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void CheckClickFire1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClick?.Invoke();
        }
    }

    private void CheckCursorPosition()
    {
        Vector2 cursorPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        OnCheckCursorPosition?.Invoke(cursorPos);
    }
}