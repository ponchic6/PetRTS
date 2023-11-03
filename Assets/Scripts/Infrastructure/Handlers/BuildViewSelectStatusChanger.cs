using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildViewSelectStatusChanger : MonoBehaviour, ISelectable
{
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _deselectColor;
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

    public void Select()
    {
        _isSelect = true;
        GetComponent<MeshRenderer>().material.color = _selectColor;
    }

    public void Deselect()
    {
        _isSelect = false;
        GetComponent<MeshRenderer>().material.color = _deselectColor;
    }
}