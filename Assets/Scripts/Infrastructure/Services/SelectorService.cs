using System;
using UnityEngine;

public class SelectorService : ISelectorService 
{
    public event Action<Rect> OnChangeRect;
    public event Action<bool> OnChangeDrawStatus;


    private readonly IInputService _inputService;
    private readonly ITickService _tickService;
    private readonly SelectableListService _selectableListService;
    private readonly IUIFactory _uiFactory;

    private Rect _currentSelectorRect;
    private Rect _pastSelectorRect;
    private Vector2 _endCursorPos;
    private Vector2 _startCursorPos;
    private bool _isCanDrawRect;

    public SelectorService(IInputService inputService, ITickService tickService,
        SelectableListService selectableListService, IUIFactory uiFactory)
    {
        _inputService = inputService;
        _inputService.OnLeftClickDown += StartDrawRect;
        _inputService.OnLeftClickUp += FinishDrawRect;

        _tickService = tickService;
        _tickService.OnTick += SelectObjectsInRect;

        _selectableListService = selectableListService;
        
        _uiFactory = uiFactory;
    }

    private void StartDrawRect()
    {
        _isCanDrawRect = true;
        _startCursorPos = _inputService.GetCursorPos();
        OnChangeDrawStatus?.Invoke(_isCanDrawRect);
    }
    
    private void FinishDrawRect()
    {
        _isCanDrawRect = false;
        OnChangeDrawStatus?.Invoke(_isCanDrawRect);
    }

    private void SelectObjectsInRect()
    {    
        CreateRectWithMouse();
        
        if (_isCanDrawRect && _pastSelectorRect != _currentSelectorRect)
        {
            for (int i = 0; i < _selectableListService.AllSelectableUnits.Count; i++)
            {
                ISelectable currentUnit = _selectableListService.AllSelectableUnits[i];
            
                Vector2 objectPosOnScreen =
                    Camera.main.WorldToScreenPoint(currentUnit.GetTransform().position);
                objectPosOnScreen.y -= Screen.height;
                objectPosOnScreen.y *= -1;

                if (_currentSelectorRect.Contains(objectPosOnScreen))
                {
                    if (!_selectableListService.CurrentSelectUnits.Contains(currentUnit))
                        _selectableListService.CurrentSelectUnits.Add(currentUnit);
                    
                    currentUnit.Select();
                    _uiFactory.CreateIconOnSelectPanel(currentUnit);
                }
                
                else
                {
                    if (_selectableListService.CurrentSelectUnits.Contains(currentUnit))
                        _selectableListService.CurrentSelectUnits.Remove(currentUnit);
                    
                    currentUnit.Deselect();
                    _uiFactory.DestroyIconOnSelectPanel(currentUnit);
                }
            }
        }

        _pastSelectorRect = _currentSelectorRect;
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
            OnChangeRect?.Invoke(_currentSelectorRect);
        }
    }
}