using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class ViewSelectStatusChange : MonoBehaviour 
{
    [SerializeField] private Image _icon;
    
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

    public Image GetIcon()
    {
        return _icon;
    }

    public bool IsSelect()
    {
        return _isSelect;
    }

    public virtual void Select()
    {
        _isSelect = true;
    }

    public virtual void Deselect()
    {
        _isSelect = false;
    }
}