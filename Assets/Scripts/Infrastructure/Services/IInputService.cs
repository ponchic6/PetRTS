using System;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClick; 
    public Vector2 GetCursorPos();
}