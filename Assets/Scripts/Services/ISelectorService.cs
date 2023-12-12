using System;
using UnityEngine;

namespace Services
{
    public interface ISelectorService
    {
        public event Action<Rect> OnChangeRect;
        public event Action<bool> OnChangeDrawStatus;
    }
}