using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectorService : ISelectorService
{
    public event Action<Rect> OnChangeRect;
    public event Action<bool> OnChangeDrawStatus;

    private readonly IInputService _inputService;
    private readonly ITickService _tickService;
    private readonly SelectableListService _selectableListService;

    private Rect _currentSelectorRect;
    private Rect _pastSelectorRect;
    private Vector2 _endCursorPos;
    private Vector2 _startCursorPos;
    private bool _isCanDrawRect;

    public SelectorService(IInputService inputService, ITickService tickService,
        SelectableListService selectableListService)
    {
        _inputService = inputService;
        _inputService.OnLeftClickDown += StartDrawRect;
        _inputService.OnLeftClickDown += TrySelectByClick;
        _inputService.OnLeftClickUp += FinishDrawRect;

        _tickService = tickService;
        _tickService.OnTick += SelectObjectsInRect;

        _selectableListService = selectableListService;
    }

    private void TrySelectByClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());

        if (IsCursorOnUI()) return;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity) &&
            raycastHit.collider.gameObject.TryGetComponent(out SelectStatusChanger selectableObject))
        {
            DeselectAll();
            selectableObject.Select();
            return;
        }

        if (Physics.Raycast(ray, out RaycastHit raycastHit1, Mathf.Infinity, 1 << 6))
        {
            DeselectAll();
        }
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
        if (IsCursorOnUI()) return;
        
        if (_isCanDrawRect && _pastSelectorRect != _currentSelectorRect && _currentSelectorRect.size.magnitude != 0)
        {
            for (int i = 0; i < _selectableListService.AllSelectableObjects.Count; i++)
            {
                SelectStatusChanger currentSelectableObject = _selectableListService.AllSelectableObjects[i];

                Vector2 objectPosOnScreen =
                    Camera.main.WorldToScreenPoint(currentSelectableObject.GetTransform().position);
                objectPosOnScreen.y -= Screen.height;
                objectPosOnScreen.y *= -1;
                
                if (_currentSelectorRect.Contains(objectPosOnScreen))
                {
                    currentSelectableObject.Select();
                } 
                
                else
                {
                    currentSelectableObject.Deselect();
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

    private void DeselectAll()
    {
        for (int i = 0; i < _selectableListService.AllSelectableObjects.Count; i++)
        {
            SelectStatusChanger currentSelectableObject = _selectableListService.AllSelectableObjects[i];
            currentSelectableObject.Deselect();
        }
    }

    private bool IsCursorOnUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        return false;
    }
}