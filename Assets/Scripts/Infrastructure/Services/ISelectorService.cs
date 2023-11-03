using System;
using UnityEngine;

public interface ISelectorService
{
    public event Action<Rect> OnChangeRect;
    public event Action<bool> OnChangeDrawStatus;

}