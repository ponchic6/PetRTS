using System;
using UnityEngine;

public class InputService : IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
         
    public InputService(ITickService tickService)
    {
        tickService.OnTick += CheckCursorPosition;
    }

    private void CheckCursorPosition()
    {
        Vector2 cursorPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        OnCheckCursorPosition?.Invoke(cursorPos);
    }
}