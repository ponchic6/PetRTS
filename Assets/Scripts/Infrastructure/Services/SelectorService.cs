using System;
using UnityEngine;

public class SelectorService : ISelectorService 
{
    public event Action<Rect> OnChangeSelectRect;
    public event Action<bool> OnStartDraw;
    public event Action<bool> OnFinishDraw;

    private readonly IInputService _inputService;
    private readonly ITickService _tickService;

    private Rect _currentSelectorRect;
    private Vector2 _endCursorPos;
    private Vector2 _startCursorPos;
    private bool _isCanDrawRect;

    public SelectorService(IInputService inputService, ITickService tickService)
    {
        _inputService = inputService;
        _inputService.OnLeftClickDown += StartDrawRect;
        _inputService.OnLeftClickUp += FinishDrawRect;
        
        _tickService = tickService;
        _tickService.OnTick += CreateRectWithMouse;
    }

    private void StartDrawRect()
    {
        _isCanDrawRect = true;
        _startCursorPos = _inputService.GetCursorPos();
        OnStartDraw?.Invoke(_isCanDrawRect);
    }
    
    private void FinishDrawRect()
    {
        _isCanDrawRect = false;
        OnFinishDraw?.Invoke(_isCanDrawRect);
    }
    
    private void CreateRectWithMouse()
    {
        if (_isCanDrawRect)
        {
            _endCursorPos = _inputService.GetCursorPos();
            
            _currentSelectorRect = new Rect(Mathf.Min(_endCursorPos.x, _startCursorPos.x),
                Screen.height - Mathf.Max(_endCursorPos.y, _startCursorPos.y),
                Mathf.Max(_endCursorPos.x, _startCursorPos.x) - Mathf.Min(_endCursorPos.x, _startCursorPos.x),
                Mathf.Max(_endCursorPos.y, _startCursorPos.y) - Mathf.Min(_endCursorPos.y, _startCursorPos.y));
            
            OnChangeSelectRect?.Invoke(_currentSelectorRect);
        }
    }
}