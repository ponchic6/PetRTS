using System;
using UnityEngine;

public interface ICameraMoverService
{
    public event Action<Vector3> OnReachCursorScreenBoundary;
    public event Action<Vector3> OnChangeCursorPosWithHoldDownMiddleButton;
}