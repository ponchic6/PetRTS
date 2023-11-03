using System;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClickDown;
    public event Action OnLeftClickUp;
    public event Action OnHoldDownMiddleButton;
    public event Action OnMiddleClickDown;
    public event Action OnMiddleClickUp;
    
    public Vector2 GetCursorPos();
}