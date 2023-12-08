using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class SelectStatusChanger : MonoBehaviour
{
    public event Action OnSelected;
    public event Action OnDecelected;

    [SerializeField] private Image _selectionIcon;
    [SerializeField] private GameObject _selectRing;
    
    private SelectableListService _selectableListService;
    private IUIFactory _uiFactory;
    private bool _isSelect;

    [Inject]
    public void Constructor(SelectableListService selectableListService, IUIFactory uiFactory)
    {
        _selectableListService = selectableListService;
        _selectableListService.AllSelectableObjects.Add(this);

        _uiFactory = uiFactory;
    }

    public void Select()
    {
        if (!_isSelect)
        {
            _isSelect = true;
            
            if (!_selectableListService.CurrentSelectObjects.Contains(this))
            {
                _selectableListService.CurrentSelectObjects.Add(this);                
            }

            _uiFactory.CreateIconOnSelectPanel(this);
            OnSelected?.Invoke();
        }
        _selectRing.SetActive(true);
    }

    public void Deselect()
    {
        if (_isSelect)
        {
            _isSelect = false;
            
            if (_selectableListService.CurrentSelectObjects.Contains(this))
                _selectableListService.CurrentSelectObjects.Remove(this);
            
            _uiFactory.DestroyIconOnSelectPanel(this);
            OnDecelected?.Invoke();
        }
        _selectRing.SetActive(false);
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
}