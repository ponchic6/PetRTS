using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public abstract class ViewSelectStatusChanger : MonoBehaviour
{
    public event Action OnSelected;
    public event Action OnDecelected;

    [SerializeField] private Image _selectionIcon;

    private SelectableListService _selectableListService;
    private bool _isSelect;

    [Inject]
    public void Constructor(SelectableListService selectableListService)
    {
        _selectableListService = selectableListService;
        _selectableListService.AllSelectableUnits.Add(this);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public Image GetSelectionIcon()
    {
        return _selectionIcon;
    }

    public bool IsSelect()
    {
        return _isSelect;
    }

    public virtual void Select()
    {
        if (!_isSelect)
        {
            _isSelect = true;
            OnSelected?.Invoke();
        }
    }

    public virtual void Deselect()
    {
        if (_isSelect)
        {
            _isSelect = false;
            OnDecelected?.Invoke();
        }
    }
}