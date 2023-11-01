using System;
using UnityEngine;

public interface ISelectorService
{
    public event Action<Rect> OnChangeSelectRect;
    public event Action<bool> OnStartDraw;
    public event Action<bool> OnFinishDraw;
    
}