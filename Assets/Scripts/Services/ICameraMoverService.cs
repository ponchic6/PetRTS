using System;
using UnityEngine;

namespace Services
{
    public interface ICameraMoverService
    {
        public event Action<Vector3> OnReachCursorScreenBoundary;
        public event Action<Vector3> OnChangeCursorPosWithHoldDownMiddleButton;
    }
}