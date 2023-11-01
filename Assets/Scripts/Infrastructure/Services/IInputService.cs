﻿using System;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector2> OnCheckCursorPosition;
    public event Action OnLeftClickDown;
    public event Action OnLeftClickUp;
    public Vector2 GetCursorPos();
}