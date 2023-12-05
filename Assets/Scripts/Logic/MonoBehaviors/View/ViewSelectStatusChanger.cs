using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class ViewSelectStatusChanger : MonoBehaviour
{
    public event Action OnSelected;
    public event Action OnDecelected;

    [SerializeField] private Image _selectionIcon;
    [SerializeField] private GameObject _selectRing;
    
    private SelectableListService _selectableListService;
    private bool _isSelect;

    [Inject]
    public void Constructor(SelectableListService selectableListService)
    {
        _selectableListService = selectableListService;
        _selectableListService.AllSelectableObjects.Add(this);
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

    public void Select()
    {
        if (!_isSelect)
        {
            _isSelect = true;
            OnSelected?.Invoke();
        }
        _selectRing.SetActive(true);
    }

    public void Deselect()
    {
        if (_isSelect)
        {
            _isSelect = false;
            OnDecelected?.Invoke();
        }
        _selectRing.SetActive(false);
    }
}